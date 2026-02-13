using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Configration
{
    public class MasterLocationConfigration : IEntityTypeConfiguration<MasterLocation>
    {
        public void Configure(EntityTypeBuilder<MasterLocation> builder) 
        {
            builder.ToTable("com_mst_location");
            builder.HasKey(x => x.LocationId);
        }
    }
}
