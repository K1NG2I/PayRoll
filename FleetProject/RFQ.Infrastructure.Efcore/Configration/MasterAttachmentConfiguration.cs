using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFQ.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Infrastructure.Efcore.Configration
{
    public class MasterAttachmentConfiguration : IEntityTypeConfiguration<MasterAttachment>
    {
        public void Configure(EntityTypeBuilder<MasterAttachment> builder)
        {
            builder.ToTable("com_mst_attachment");
            builder.HasKey(x => x.AttachmentId);
        }
    }
}
