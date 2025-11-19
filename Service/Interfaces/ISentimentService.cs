using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ISentimentService
    {
        Task<List<NewsFeedCommentModel>> AnalyzeSentimentsAsync(List<string> badWords);    
    }
}
