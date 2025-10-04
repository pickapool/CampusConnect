using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamCon.Domain.Enitity
{
    [Table("ProfileInformation")]
    [PrimaryKey("ProfileInformationId")]
    public class ProfileInfo
    {
        public Guid ProfileInformationId { get; set; }

    }
}
