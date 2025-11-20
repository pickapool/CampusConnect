using CamCon.Shared;
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
        Task<Result> AddSentimentAsync(SentimentModel sentiment);

        Task<List<SentimentModel>> GetSentimentsAsync();

        Task<Result> DeleteSentimentAsync(SentimentModel sentiment);
    }
}
