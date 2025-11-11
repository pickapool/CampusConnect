using Domain.Models;

namespace Domain
{
    public class PaginationResponseModel
    {
        public int Count { get; set; }
        public List<NewsFeedModel> Records { get; set; } = [];
    }
}
