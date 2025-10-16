using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public string? Photo => ProfilePicture is null ? "/images/blank_profile.png" : $"data:image/png;base64,{Convert.ToBase64String(ProfilePicture)}";


    }
}
