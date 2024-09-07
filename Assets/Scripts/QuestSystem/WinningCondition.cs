using UnityEngine;

namespace QuestSystem
{
    [CreateAssetMenu(fileName = "QWC", menuName = "QuestSystem/WinningCondition", order = 0)]
    public abstract class WinningCondition
    {
        public abstract bool IsDone();
    }
}
