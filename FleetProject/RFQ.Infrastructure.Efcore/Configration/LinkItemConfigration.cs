using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Configration
{
    public class LinkItemConfigration : IEntityTypeConfiguration<LinkItem>
    {

        public void Configure(EntityTypeBuilder<LinkItem> builder)
        {
            builder.ToTable("com_mst_link_item");
            builder.HasKey(x => x.LinkId);
        }
    }
}
