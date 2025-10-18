namespace Domain.Models
{
    public class NewsFeedImageModel
    {
        public Guid NewsFeedImageId { get; set; }

        public byte[] ImageData { get; set; } = Array.Empty<byte>();

        public Guid NewsFeedId { get; set; }
    }
}
