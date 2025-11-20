using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SentimentModel
    {
        public Guid SentimentId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
