namespace Domain.Models
{
    public class NewsFeedImageModel
    {
        public Guid NewsFeedImageId { get; set; }

        public byte[] ImageData { get; set; } = Array.Empty<byte>();

        public Guid NewsFeedId { get; set; }

        public string Image => ImageData.Length <= 0 ? "" : $"data:image/png;base64,{Convert.ToBase64String(ImageData)}";
    }
}
