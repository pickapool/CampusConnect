namespace Domain.Models
{
    public class AdminPageRequestModel
    {
        public Guid AdminPageRequestId { get; set; }
        
        public string? Id { get; set; }

        public ApplicationUserModel? User { get; set; }

        public Guid? MyOrganizationId { get; set; }

        public MyOrganizationModel? MyOrganization { get; set; }

        public Enums.PageRequestStatus PageRequestStatus { get; set; }

    }
}
