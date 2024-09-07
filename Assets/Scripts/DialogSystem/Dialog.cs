using UnityEngine;
using UnityEngine.Events;

namespace DialogSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "DialogNode", menuName = "DialogSystem/Dialog", order = 0)]
    public class Dialog : ScriptableObject
    {
        public DialogNode startNode;

        public UnityEvent onStart;
    }
}
