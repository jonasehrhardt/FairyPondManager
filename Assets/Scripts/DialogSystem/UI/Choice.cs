using TMPro;
using UnityEngine;

namespace DialogSystem.UI
{
    public class Choice : MonoBehaviour
    {
        [SerializeField] private NodeDisplayer _nodeDisplayer;
        [SerializeField] private DialogSystem.Choice _choice;
        [SerializeField] private TextMeshProUGUI _textToDisplay;
        public void ApplyChoice(DialogSystem.Choice choice, NodeDisplayer nodeDisplayer)
        {
            this._nodeDisplayer = nodeDisplayer;
            _choice = choice;
            _textToDisplay.text = choice.answer;
        }

        public void DoChoice()
        {
            DialogEventHandler.PlayEvents(_choice.events);
            _nodeDisplayer.DisplayNode(_choice.node);
        }
    }
}
