using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamCon.Domain.Enitity
{
    [Table("MyOrganizations")]
    [PrimaryKey("MyOrganizationId")]
    public class MyOrganizationModel
    {
        public Guid MyOrganizationId { get; set; }
        public string OrganizationName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Enums.OrganizationType OrganizationType { get; set; }

        //Profile
        public string? Id { get; set; }
        [ForeignKey("Id")]
        public ApplicationUserModel? User { get; set; }
    }
}
