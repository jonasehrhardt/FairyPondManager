using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace DialogSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "DialogNode", menuName = "DialogSystem/Node", order = 1)]
    public class DialogNode : ScriptableObject
    {
        public string text;
        public List<Choice> choices;
        [SerializeField] protected DialogNode _nextNode;

        public UnityEvent onEnterNode;

        public bool IsLinear => !_nextNode.IsUnityNull() && choices.Count == 0;
        public bool IsEnd => _nextNode.IsUnityNull() && choices.Count == 0;
    }
}
