namespace Infrastructure.Extensions
{
    public static class ObjectExtensions
    {
        public static object Wrap(this object model, string key)
        {
            return new Dictionary<string, object>
            {
                [key] = model
            };
        }
    }
}
