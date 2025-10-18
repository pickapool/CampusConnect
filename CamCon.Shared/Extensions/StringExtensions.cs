namespace CamCon.Shared.Extensions
{
    public static class StringExtensions
    {
        public static bool IsCapitalized(this string str)
        {
            return !string.IsNullOrEmpty(str) && char.IsUpper(str[0]);
        }

        public static string GetInitials(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            var words = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 1)
                return words[0][0].ToString().ToUpper();

            var firstInitial = char.ToUpper(words.First()[0]);
            var lastInitial = char.ToUpper(words.Last()[0]);

            return $"{firstInitial}{lastInitial}";
        }

    }
}
