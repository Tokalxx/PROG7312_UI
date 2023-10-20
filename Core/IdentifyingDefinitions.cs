using System.Collections.Generic;

namespace PROG7312_UI.Core
{
    internal class IdentifyingDefinitions
    {
        private static readonly IdentifyingDefinitions _instance = new IdentifyingDefinitions();
        Dictionary<string, string> CallDefinition = new Dictionary<string, string>();

        private IdentifyingDefinitions()
        {
            CallDefinition.Add("000 ", "Computer Science, Information, & General Works");
            CallDefinition.Add("100 ", "Philosophy & Psychology");
            CallDefinition.Add("200 ", "Religion");
            CallDefinition.Add("300 ", "Social Sciences");
            CallDefinition.Add("400 ", "Language");
            CallDefinition.Add("500 ", "Science");
            CallDefinition.Add("600 ", "Technology");
            CallDefinition.Add("700  ", "Arts & Recreation");
            CallDefinition.Add("800  ", "Literature");
            CallDefinition.Add("900  ", "History & Geography");
        }

        public static IdentifyingDefinitions GetDefinition()
        {
            return _instance;
        }

        public Dictionary<string, string> GetCallDefinition()
        {
            return CallDefinition;
        }
    }
}
