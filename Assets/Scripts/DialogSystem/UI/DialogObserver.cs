using UnityEngine;

namespace DialogSystem.UI
{
    public class DialogObserver : MonoBehaviour
    {
        private Dialog _dialog;
        [SerializeField] private NodeDisplayer _displayer;

        public void EnterDialog(Dialog dialog)
        {
            _dialog = dialog;
            _displayer.DisplayNode(_dialog.startNode);
        }
    }
}
