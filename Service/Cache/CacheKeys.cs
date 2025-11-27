using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Cache
{
    public static class CacheKeys
    {
        public static class UserKey
        {
            public static CacheKey BaseKey = new(nameof(UserKey), TimeSpan.FromDays(1));

            public static CacheKey ByUserId(string id) => BaseKey.Append("ByUserId", id);
        }

    }

    public record struct CacheKey(string Key, TimeSpan Duration)
    {

        public CacheKey Append(params object[] keySuffixes)
        {
            StringBuilder builder = new(this.Key);

            foreach (var item in keySuffixes)
                builder.Append(':').Append(item);

            return this with { Key = builder.ToString() };

        }

        public override string ToString() => $"{this.Key} ({this.Duration})";
    }
}
