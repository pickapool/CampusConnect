using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{   
    public class ApplicationUserModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public Guid? ProfileInformationId { get; set; }
        public ProfileInfo? ProfileInformation { get; set; }

        public bool IsWebCreated { get; set; }
    }
}
