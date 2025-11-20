using CamCon.Shared;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IGeminiService
    {
        Task<List<NewsFeedCommentModel>> AnalyzeSentimentsAsync(List<string> badWords);    

    }
}
