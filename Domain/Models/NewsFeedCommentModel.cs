namespace Domain.Models
{
    public class NewsFeedCommentModel
    {
        public Guid NewsFeedCommentId { get; set; }

        public string? Id { get; set; }

        public ApplicationUserModel? User { get; set; }

        public string Message { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<NewsFeedCommentModel> Replies { get; set; } = new();

        public Guid NewsFeedId { get; set; }

        public Guid? ParentCommentId { get; set; }
    }
}
