using Assets.Scripts.Structs;
using UnityEngine.Events;
using UnityEngine;
namespace WorldView
{
    public class TwoWorldsGlobalObserver : MonoSingleton<TwoWorldsGlobalObserver>
    {
        public UnityEvent<state> onWorldChange;
        [SerializeField] private state _currentState;
        public void ChangeWorldView()
        {
            _currentState = state.real == _currentState ? state.fantasy : state.real;
            onWorldChange?.Invoke(_currentState);
        }

        private void Start()
        {
            onWorldChange?.Invoke(_currentState);
        }

        public enum state : int
        {
            real = -1,
            fantasy = 1
        }
    }
}
