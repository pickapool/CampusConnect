using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface INewsFeedService
    {
        Task CreatePost(NewsFeedModel newsFeed);
        Task<NewsFeedModel> GetPostById(Guid guid);
        Task<List<NewsFeedModel>> GetNewsFeeds();
        Task<List<NewsFeedModel>> GetNewsFeedById(Guid guid);
    }
}
