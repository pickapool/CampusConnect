using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamCon.Domain.Models
{
    [Table("ProfileInformation")]
    [PrimaryKey("ProfileInformationId")]
    public class ProfileInfo
    {
        public Guid ProfileInformationId { get; set; }

    }
}
