using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Configration
{
    public class CompanyConfigration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("com_mst_company");
            builder.HasKey(x => x.CompanyId);
            builder.Property(x => x.CompanyId).HasColumnName("CompanyId");
            builder.Property(x => x.CompanyName).HasColumnName("CompanyName").HasMaxLength(200);
            builder.Property(x => x.CompanyTypeId).HasColumnName("CompanyTypeId").HasDefaultValue(0);
            builder.Property(x => x.AddressLine).HasColumnName("AddressLine").HasMaxLength(500);
            builder.Property(x => x.CityId).HasColumnName("CityId").HasDefaultValue(0);
            builder.Property(x => x.PinCode).HasColumnName("PinCode").HasMaxLength(50);
            builder.Property(x => x.ContactPerson).HasColumnName("ContactPerson").HasMaxLength(200);
            builder.Property(x => x.ContactNo).HasColumnName("ContactNo").HasMaxLength(50);
            builder.Property(x => x.MobNo).HasColumnName("MobNo").HasMaxLength(50);
            builder.Property(x => x.WhatsAppNo).HasColumnName("WhatsAppNo").HasMaxLength(50);
            builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(200);
            builder.Property(x => x.PANNo).HasColumnName("PANNo").HasMaxLength(50);
            builder.Property(x => x.GSTNo).HasColumnName("GSTNo").HasMaxLength(50);
            builder.Property(x => x.LogoImage).HasColumnName("LogoImage").HasMaxLength(150);
            builder.Property(x => x.ParentCompanyId).HasColumnName("ParentCompanyId").HasDefaultValue(0);
            builder.Property(x => x.LinkId).HasColumnName("LinkId").HasDefaultValue(0);
            builder.Property(x => x.StatusId).HasColumnName("StatusId");
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasDefaultValue(1);
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn");
            builder.Property(x => x.UpdatedBy).HasColumnName("UpdatedBy").HasDefaultValue(1);
            builder.Property(x => x.UpdatedOn).HasColumnName("UpdatedOn");

        }
    }
}
