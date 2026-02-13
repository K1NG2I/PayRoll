namespace RFQ.Domain.RequestDto
{
    public class MasterUserActivityLogDto
    {
        public int? LogUid { get; set; }

        public int? LogLinkId { get; set; }

        public int? LogTypeId { get; set; }

        public int? UserId { get; set; }

        public DateTime? LogDateTime { get; set; }

        public string? Description { get; set; }
    }
}
