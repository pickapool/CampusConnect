using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICommentService
    {
        Task<NewsFeedCommentModel> AddCommentAsync(NewsFeedCommentModel comment);
        Task<List<NewsFeedCommentModel>> GetCommentsByNewsFeedIdAsync(Guid newsFeedId);
        Task<NewsFeedCommentModel> DeleteComment(Guid guid);
        Task<NewsFeedCommentModel> FlaggedComment(Guid guid);

    }
}
