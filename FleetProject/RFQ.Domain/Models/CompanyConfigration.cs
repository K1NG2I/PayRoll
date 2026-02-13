using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFQ.Domain.Models
{
    [Table("com_mst_company_config")]
    public class CompanyConfigration
    {
        [Key]
        public int CompanyConfigId { get; set; }

        public int? CompanyId { get; set; }

        public string? SMSProvider { get; set; }

        public string? SMSAuthKey { get; set; }

        public string? WhatsAppProvider { get; set; }

        public string? WhatsAppAuthKey { get; set; }

        public string? SMTPHost { get; set; }

        public int? SMTPPort { get; set; }

        public string? SMTPUsername { get; set; }

        public string? SMTPPassword { get; set; }
        public int? StatusId { get; set; }
    }
}
