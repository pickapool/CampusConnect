using CamCon.Shared;

namespace WebAPI.Constants
{
    public class StatusCodeErrors
    {
        public static Error StatusCode(int code, string description) => new(code, description);
    }
}
