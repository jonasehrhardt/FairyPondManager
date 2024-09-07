using System.Collections.Generic;
using UnityEngine.Events;

namespace QuestSystem
{
    [System.Serializable]
    public class Quest
    {
        public bool finished;
        public string description;
        public UnityEvent passQuest;
        public List<WinningCondition> winningConditions;

        public void PassQuest()
        {
            if (!IsReadyToPass() || finished)
                return;

            passQuest?.Invoke();
            finished = true;
        }

        public bool IsReadyToPass()
        {
            foreach (var winningCondition in winningConditions)
            {
                if(!winningCondition.IsDone())
                    return false;
            }

            return true;
        }
    }
}
