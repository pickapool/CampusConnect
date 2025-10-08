namespace Domain.Models
{
    public class MyOrganizationModel
    {
        public Guid MyOrganizationId { get; set; }
        public string OrganizationName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        //Profile
        public string? Id { get; set; }
        public ApplicationUserModel? User { get; set; }
    }
}
