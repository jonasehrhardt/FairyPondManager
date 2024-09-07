using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.Events;

namespace WorldView
{
    public class TwoWorldsEntity : MonoBehaviour
    {
        [SerializeField] private SerializedDictionary<TwoWorldsGlobalObserver.state, UnityEvent> _reactions;

        private void ReactOnWorldChange(TwoWorldsGlobalObserver.state state)
            => _reactions[state]?.Invoke();

        protected virtual void OnEnable()
        {
            TwoWorldsGlobalObserver.Instance.onWorldChange.AddListener(ReactOnWorldChange);
        }

        protected virtual void OnDisable()
        {
            TwoWorldsGlobalObserver.Instance.onWorldChange.RemoveListener(ReactOnWorldChange);
        }
    }
}
