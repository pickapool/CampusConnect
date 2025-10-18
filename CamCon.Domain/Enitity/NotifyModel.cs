using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CamCon.Domain.Enitity
{
    [Table("Notifications")]
    [PrimaryKey("NotifyId")]
    public class NotifyModel
    {
        public Guid NotifyId { get; set; }

        public Enums.NotificationType NotificationType { get; set; }

        public string DataJson { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsRead { get; set; }
    }

    public class NotifyModel<T> : NotifyModel
    {
        [NotMapped]
        public T? Data
        {
            get => string.IsNullOrWhiteSpace(DataJson)
                ? default
                : JsonSerializer.Deserialize<T>(DataJson);
            set => DataJson = JsonSerializer.Serialize(value);
        }
    }

}
