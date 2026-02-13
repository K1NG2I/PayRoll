using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Configration
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("com_mst_vehicle");
            builder.HasKey(x => x.VehicleId);

            // set precision for decimal columns to avoid truncation warnings
            builder.Property(v => v.GrossWeight).HasPrecision(18, 3);
            builder.Property(v => v.UnladenWeight).HasPrecision(18, 3);
        }
    }
}
