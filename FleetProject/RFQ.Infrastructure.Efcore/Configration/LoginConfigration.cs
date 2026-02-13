using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Configration
{
    public class LoginConfigration : IEntityTypeConfiguration<Register>
    {

        public void Configure(EntityTypeBuilder<Register> builder)
        {

        }
    }
}
