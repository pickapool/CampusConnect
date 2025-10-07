namespace Domain.Models
{
    public class MyOrganizationModel
    {
        public Guid MyOrganizationId { get; set; }
        public string OrganizationName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        //Profile
        public Guid? ProfileInformationId { get; set; }

        public ProfileInfo? ProfileInfo { get; set; }
    }
}
