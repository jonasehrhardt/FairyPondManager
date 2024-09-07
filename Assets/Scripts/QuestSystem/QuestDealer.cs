using QuestSystem;
using UnityEngine;

namespace Assets.Scripts.QuestSystem
{
    public class QuestDealer : MonoBehaviour
    {
        public Quest quest;
        public bool hasBeenGiven;
        public void GiveQuest()
        {
            if (hasBeenGiven)
                return;

            hasBeenGiven = true;
            QuestList.Instance.TakeQuest(quest);
        }
    }
}
