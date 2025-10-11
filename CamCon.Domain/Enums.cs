using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamCon.Domain
{
    public class Enums
    {
        public enum RequestType
        {
            GET,
            POST,
            DELETE,
            PUT
        }
        public enum OrganizationType
        {
            Department,
            Organization
        }
    }
}
