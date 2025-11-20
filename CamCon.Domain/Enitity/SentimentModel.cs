using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamCon.Domain.Enitity
{
    [Table("Sentiments")]
    [PrimaryKey("SentimentId")]
    public class SentimentModel
    {
        public Guid SentimentId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
