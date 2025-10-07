namespace Domain.Models
{
    public class ProfileInfo
    {
        public Guid ProfileInformationId { get; set; }

        public bool IsAdmin { get; set; }

        public byte[] ProfilePicture { get; set; } = [];

        //Department
        public Guid? DepartmentId { get; set; }
        public DepartmentModel? Department { get; set; }

    }
}
