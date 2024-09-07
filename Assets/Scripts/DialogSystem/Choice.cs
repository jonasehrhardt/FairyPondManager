using System.Collections.Generic;

namespace DialogSystem
{
    [System.Serializable]
    public class Choice
    {
        public string answer;
        public string[] events;
        public DialogNode node;
    }
}
