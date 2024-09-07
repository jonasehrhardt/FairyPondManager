using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DialogSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "DialogNode", menuName = "DialogSystem/Node", order = 1)]
    public class DialogNode : ScriptableObject
    {
        public string text;
        public List<Choice> choices;
        public DialogNode nextNode;

        public bool IsLinear => !nextNode.IsUnityNull() && choices.Count == 0;
        public bool IsEnd => nextNode.IsUnityNull() && choices.Count == 0;
    }
}
