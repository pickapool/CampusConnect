using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class LikeModel
    {
        public Guid LikeId { get; set; }

        public Enums.LikeType LikeType { get; set; }

        public string? UserId { get; set; }

        public string Emoji { get; set; } = string.Empty;

        public Guid NewsFeedId { get; set; }
    }
}
