using Assets.Scripts.Structs;
using System.Collections.Generic;
using UnityEngine.Events;

namespace QuestSystem
{
    public class QuestList : MonoSingleton<QuestList>
    {
        public List<Quest> quests;
        public UnityEvent<Quest> onQuestTake;

        public void TakeQuest(Quest quest)
        {
            quests.Add(quest);
            onQuestTake.Invoke(quest);
        }
    }
}
