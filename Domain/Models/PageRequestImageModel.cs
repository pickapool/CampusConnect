namespace Domain.Models
{
    public class PageRequestImageModel
    {
        public Guid PageRequestImageId { get; set; }
        public Guid AdminPageRequestId { get; set; }
        public byte[]? Image { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public string Filename { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
    }
}
