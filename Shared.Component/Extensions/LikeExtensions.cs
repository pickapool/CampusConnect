using static Domain.Enums;

namespace Shared.Component.Extensions
{
    public static class LikeExtensions
    {
        public static string ToEmoji(this LikeType type)
        {
            return type switch
            {
                LikeType.Like => "👍",
                LikeType.Heart => "❤️",
                LikeType.Funny => "😆",
                LikeType.Wow => "😮",
                LikeType.Cry => "😢",
                LikeType.Angry => "😠",
                _ => ""
            };
        }
    }
}
