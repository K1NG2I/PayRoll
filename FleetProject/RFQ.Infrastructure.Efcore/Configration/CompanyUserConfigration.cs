using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Configration
{
    public class CompanyUserConfigration : IEntityTypeConfiguration<CompanyUser>
    {

        public void Configure(EntityTypeBuilder<CompanyUser> builder)
        {
            builder.ToTable("com_mst_user");
            builder.HasKey(x => x.UserId);
        }
    }
}
