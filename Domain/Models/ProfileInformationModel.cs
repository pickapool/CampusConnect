using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class ProfileInfo
    {
        public Guid ProfileInformationId { get; set; }

        public bool IsAdmin { get; set; }

        public byte[]? ProfilePicture { get; set; }

        //Org
        public Guid? MyOrganizationId { get; set; }

        public MyOrganizationModel? MyOrganization { get; set; }

    }
}
