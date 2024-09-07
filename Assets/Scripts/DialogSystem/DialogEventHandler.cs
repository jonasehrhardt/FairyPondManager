using Assets.Scripts.Structs;
using AYellowpaper.SerializedCollections;
using UnityEngine.Events;

namespace DialogSystem
{
    public class DialogEventHandler : MonoSingleton<DialogEventHandler>
    {
        public SerializedDictionary<string, UnityEvent> events;

        public static void PlayEvents(params string[] eventNames)
        {
            foreach (string eventName in eventNames)
                Instance.events[eventName].Invoke();
        }
    }
}
