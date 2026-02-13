using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFQ.Domain.Models;


namespace RFQ.Infrastructure.Efcore.Configration
{
    public class AttachmentTypeConfiguration : IEntityTypeConfiguration<MasterAttachmentType>
    {
        public void Configure(EntityTypeBuilder<MasterAttachmentType> builder)
        {
            builder.ToTable("com_mst_attachment_type");
            builder.HasKey(x => x.AttachmentTypeId);
        }
    }
}
