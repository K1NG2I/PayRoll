using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Configration
{
    public class ContactPersonDetailsConfiguration : IEntityTypeConfiguration<ContactPersonDetails>
    {
        public void Configure(EntityTypeBuilder<ContactPersonDetails> builder)
        {
            builder.ToTable("com_mst_contactpersondetails");
            builder.HasKey(x => x.ContactPersonDetailId);
        }
    }
}
