using UnityEngine;
namespace StateMachine {
    public class StateMachine : MonoBehaviour {
        [SerializeField] private BaseState _currentState;

        protected virtual void Start() {
            _currentState = null;
            _currentState?.Enter();
        }

        protected virtual void Update() {
            _currentState?.UpdateLogic();
        }

        protected virtual void LateUpdate() {
            _currentState?.UpdatePhysics();
            _currentState?.UpdateAnimator();
        }

        public void ChangeState(BaseState newState) {
            _currentState?.Exit();

            _currentState = newState;
            newState?.Enter();
        }

        public bool IsCurrentStateIs<T>() where T : BaseState
            => _currentState.GetType() == typeof(T);

        private void OnGUI() {
            GUILayout.BeginArea(new Rect(10f, 10f, 200f, 100f));
            string content = _currentState != null ? _currentState.name : "(no current state)";
            GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
            GUILayout.EndArea();
        }
    }
}
