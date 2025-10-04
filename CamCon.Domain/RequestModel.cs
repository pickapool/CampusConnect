using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamCon.Domain
{
    public class RequestModel
    {
        public Enum.RequestType RequestType { get; set; } = Enum.RequestType.GET;
        public string? RequestUrl { get; set; }
        public string? AccessToken { get; set; }
        public object? Data { get; set; }
    }
}
