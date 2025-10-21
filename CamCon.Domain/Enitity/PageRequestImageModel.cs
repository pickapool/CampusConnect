﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamCon.Domain.Enitity
{
    [Table("PageRequestImages")]
    [PrimaryKey("PageRequestImageId")]
    public class PageRequestImageModel
    {
        public Guid PageRequestImageId { get; set; }
        public Guid AdminPageRequestId { get; set; }
        public byte[]? Image { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
