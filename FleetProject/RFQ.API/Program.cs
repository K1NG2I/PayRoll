using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RFQ.Application.Extension;
using RFQ.Application.Helper;
using RFQ.Application.Interface;
using RFQ.Infrastructure.Efcore;
using RFQ.Infrastructure.Efcore.Extensions;
using RFQ.Web.API.Filter;
using RFQ.Web.API.MapperProfile;
using RFQ.Web.API.Validation;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder.WithOrigins("https://localhost:7265")
                          .WithOrigins("https://localhost:7075")
                          .WithOrigins("https://localhost:443")
                          .WithOrigins("https://192.168.0.72:443")
                          .WithOrigins("https://192.168.0.72:7075")
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials());
});


// Add services to the container.
builder.Services.AddAutoMapper(typeof(AutoMappersRegister));


//Add Serilog 
builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration));


builder.Services.AddControllers(config => config.Filters.Add<CommanResponseResultFilter>());
builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));
builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    .AddValidatorsFromAssemblyContaining<LoginValidation>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContextPool<AppDbContext>(option =>
//{
//    option.UseSqlServer(builder.Configuration.GetConnectionString("RfqDBConnection"));
//});
builder.Services.AddDbContext<FleetLynkDbContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("RfqDBConnection")),
             ServiceLifetime.Transient);

builder.Services.Configure<AppSettingContxt>(
    builder.Configuration.GetSection("CacheSettings"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
    AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });



//Add Bearer 
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Rfq.API", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddEfcoreInfrastrucureService();
builder.Services.AddApplicationService();
builder.Services.AddMemoryCache();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var currentUserService = scope.ServiceProvider.GetRequiredService<ICurrentUserService>();
    UserIdentityContext.Initialize(currentUserService);
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("v1/swagger.json", "Rfq.API v1");
});
app.UseCors("AllowLocalhost");
app.UseAuthorization();
app.UseAuthentication();
app.UseSerilogRequestLogging();
//app.UseHttpsRedirection();
app.MapControllers();
app.Run();


