using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class MyOrganizationModel
    {
        //List of organizations and user assinged
        public Guid MyOrganizationId { get; set; }
        public string OrganizationName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Enums.OrganizationType OrganizationType { get; set; }

        //Profile
        public string? Id { get; set; }
        public ApplicationUserModel? User { get; set; }

        public override string ToString() => OrganizationName;

        public Guid? OrganizationDepartmentId { get; set; }
        [ForeignKey("OrganizationDepartmentId")]
        public OrganizationDepartmentModel? OrganizationDepartment { get; set; }

        public byte[]? ProfilePicture { get; set; }

        public byte[]? CoverPicture { get; set; }

        [JsonIgnore]
        public string? Photo => ProfilePicture is null ? "/images/blank_profile.png" : $"data:image/png;base64,{Convert.ToBase64String(ProfilePicture)}";

        [JsonIgnore]
        public string? CoverPhoto => CoverPicture is null ? "/images/coverphoto.png" : $"data:image/png;base64,{Convert.ToBase64String(CoverPicture)}";
    }
}
