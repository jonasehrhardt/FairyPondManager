using Assets.Scripts.Structs;
using UnityEngine;

namespace DialogSystem.UI
{
    public class DialogObserver : MonoSingleton<DialogObserver>
    {
        private Dialog _dialog;
        [SerializeField] private NodeDisplayer _displayer;

        public void EnterDialog(Dialog dialog)
        {
            _dialog = dialog;
            DialogEventHandler.PlayEvents(dialog.events);
            _displayer.DisplayNode(_dialog.startNode);
        }
    }
}
