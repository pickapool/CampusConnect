using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
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
        public enum Action
        {
            Create,
            Update,
            Delete,
            None
        }
    }
}
