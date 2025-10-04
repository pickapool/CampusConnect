using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RequestModel
    {
        public Enums.RequestType RequestType { get; set; } = Enums.RequestType.GET;
        public string? RequestUrl { get; set; }
        public string? AccessToken { get; set; }
        public object? Data { get; set; }
    }
}
