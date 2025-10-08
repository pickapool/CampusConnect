using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamCon.Domain.Enitity
{
    [Table("ProfileInformation")]
    [PrimaryKey("ProfileInformationId")]
    public class ProfileInfo
    {
        public Guid ProfileInformationId { get; set; }

        public bool IsAdmin { get; set; }

        public byte[]? ProfilePicture { get; set; }

        //Department
        public Guid? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public DepartmentModel? Department { get; set; }

    }
}
