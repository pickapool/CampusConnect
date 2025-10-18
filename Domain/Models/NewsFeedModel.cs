namespace Domain.Models
{
    public class NewsFeedModel
    {
        public Guid NewsFeedId { get; set; }

        public string Message { get; set; } = string.Empty;

        public Guid MyOrganizationId { get; set; }

        public MyOrganizationModel? MyOrganization { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<NewsFeedImageModel>? Images { get; set; }

        public List<NewsFeedCommentModel>? Comments { get; set; }
    }
}
