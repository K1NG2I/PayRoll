using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Configration
{
    public class MasterPartyConfigration : IEntityTypeConfiguration<MasterParty>
    {
        public void Configure(EntityTypeBuilder<MasterParty> builder)
        {
            builder.ToTable("com_mst_party");
            builder.HasKey(x => x.PartyId);
        }
    }
}
