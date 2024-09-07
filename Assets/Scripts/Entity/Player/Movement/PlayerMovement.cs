using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using Assets.Scripts.Entity.Player.Movement.States;

namespace Entity.Player.Movement {
    public class PlayerMovement : StateMachine.StateMachine {
        public Rigidbody rigidBody;
        public GroundCheck groundCheck;

        public States states;
        protected override void Start() {
            ChangeState(states.walk);
        }

        #region Input Reading
        public void ReadInputMovementActions(InputAction.CallbackContext ctx) {
            Vector2 input = ctx.ReadValue<Vector2>();
            //events.onMovementInput.Invoke(new Vector3(input.x, 0, input.y));
        }

        #endregion
        #region Composition Helpers
        [System.Serializable]
        public class States {
            public Walk walk;
            public Freeze freeze;
        }

        [System.Serializable]
        public class Events {
            public UnityEvent<Vector3> onMovementInput;
            public UnityEvent<InputAction.CallbackContext> onZoom;
            public UnityEvent onJump;
        }
        #endregion
    }
}
