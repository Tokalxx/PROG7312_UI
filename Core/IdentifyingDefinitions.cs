using System;
using System.Collections.Generic;
using System.Linq;

namespace PROG7312_UI.Core
{
    internal class IdentifyingDefinitions
    {
        private static readonly IdentifyingDefinitions _instance = new IdentifyingDefinitions();
        Dictionary<string, string> CallDefinition = new Dictionary<string, string>();
        Random ran = new Random();

        private IdentifyingDefinitions()
        {
            CallDefinition.Add("000", "Computer Science, Information, & General Works");
            CallDefinition.Add("100", "Philosophy & Psychology");
            CallDefinition.Add("200", "Religion");
            CallDefinition.Add("300", "Social Sciences");
            CallDefinition.Add("400", "Language");
            CallDefinition.Add("500", "Science");
            CallDefinition.Add("600", "Technology");
            CallDefinition.Add("700", "Arts & Recreation");
            CallDefinition.Add("800", "Literature");
            CallDefinition.Add("900", "History & Geography");

            //CallDefinition.Add("1", "1");
            //CallDefinition.Add("2", "2");
            //CallDefinition.Add("3", "3");
            //CallDefinition.Add("4", "4");
            //CallDefinition.Add("5", "5");
            //CallDefinition.Add("6", "6");
            //CallDefinition.Add("7", "7");
            //CallDefinition.Add("8", "8");
            //CallDefinition.Add("9", "9");
            //CallDefinition.Add("10", "10");
        }

        public static IdentifyingDefinitions GetDefinition()
        {
            return _instance;
        }

        public Dictionary<string, string> GetDeweyDictionary()
        {
            return CallDefinition;
        }

        public Dictionary<string, string> GetShuffledDictionary()
        {

            List<string> randomKeys = CallDefinition.Keys.OrderBy(x => ran.Next()).ToList();

            List<string> usedKeys = randomKeys.Take(7).ToList();

            //Dictionary<string, string> usableDictionary = usedKeys.ToDictionary(key => key, key => CallDefinition[key]);
            Dictionary<string, string> usableDictionary = usedKeys.ToDictionary(key => key, key => CallDefinition[key]);

            return usableDictionary;
        }

    }
}
