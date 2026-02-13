using RFQ.Domain.Interfaces;
namespace RFQ.Infrastructure.Efcore.Providers
{
    public class LoginRepository : IloginRepository
    {
        private readonly FleetLynkDbContext _AppdbContext;

        public LoginRepository(FleetLynkDbContext dbContext)
        {
            _AppdbContext = dbContext;
        }
        //public async Task Register(Register register)
        //{
        //    try
        //    {
        //        await _AppdbContext.Register.AddAsync(register);
        //        await _AppdbContext.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //}
    }
}
