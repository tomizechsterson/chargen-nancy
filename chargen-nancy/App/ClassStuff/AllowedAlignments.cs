using System.Collections.Generic;

namespace chargen_nancy.App.ClassStuff
{
    public class AllowedAlignments
    {
        private readonly string _className;
        private readonly Dictionary<string, string[]> _allowedAlignments;

        public AllowedAlignments(string className)
        {
            _className = className.Replace("%2F", "/").ToLower();
            _allowedAlignments = InitializeAlignments();
        }

        public string[] Get()
        {
            return _className.Contains("/") ? AllAlignments() : _allowedAlignments[_className];
        }

        private static Dictionary<string, string[]> InitializeAlignments()
        {
            return new Dictionary<string, string[]>
            {
                { "paladin", new[] { "Lawful Good" } },
                { "druid", new[] {"True Neutral"} },
                { "ranger", new[] { "Lawful Good", "Neutral Good", "Chaotic Good" } },
                { "bard", new[] { "Lawful Neutral", "Neutral Good", "True Neutral", "Neutral Evil", "Chaotic Neutral" } },
                { "fighter", AllAlignments() },
                { "mage", AllAlignments() },
                { "cleric", AllAlignments() },
                { "thief", AllAlignments() }
            };
        }

        private static string[] AllAlignments()
        {
            return new[]
            {
                "Lawful Good", "Neutral Good", "Chaotic Good", "Lawful Neutral", "True Neutral", "Chaotic Neutral",
                "Lawful Evil", "Neutral Evil", "Chaotic Evil"
            };
        }
    }
}