using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class ProfileInfo
    {
        public Guid ProfileInformationId { get; set; }

        public bool IsAdmin { get; set; }

        public string FullName { get; set; } = string.Empty;

        public byte[]? ProfilePicture { get; set; }

        public byte[]? CoverPicture { get; set; }

        //Org
        public Guid? MyOrganizationId { get; set; }
        //My Department
        public MyOrganizationModel? MyOrganization { get; set; }

        public string Address { get; set; } = string.Empty;

        public string Course { get; set; } = string.Empty;


        [JsonIgnore]
        public string? Photo => ProfilePicture is null ? "/images/blank_profile.png" : $"data:image/png;base64,{Convert.ToBase64String(ProfilePicture)}";

        [JsonIgnore]
        public string? CoverPhoto => CoverPicture is null ? "/images/coverphoto.png" : $"data:image/png;base64,{Convert.ToBase64String(CoverPicture)}";


    }
}
