using Entity.Player.Movement;
using FMOD.Studio;
using StateMachine;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity.Player.Movement.States
{
    [System.Serializable]
    public class Walk : BaseState
    {
        public float speed = 5;

        [Header("Running")]
        public bool canRun = true;
        public bool IsRunning { get; private set; }
        public float runSpeed = 9;
        public KeyCode runningKey = KeyCode.LeftShift;

        Rigidbody rigidbody;
        /// <summary> Functions to override movement speed. Will use the last added override. </summary>
        public List<Func<float>> speedOverrides = new List<Func<float>>();

        // audio
        private EventInstance playerFootsteps;
        [SerializeField] private PlayerMovement _player;
        public Walk(PlayerMovement stateMachine) : base(nameof(Walk), stateMachine)
        {
            _player = stateMachine;
        }

        public override void Enter()
        {
            //_player.events.onMovementInput.AddListener(UseInput);
            if(!rigidbody)
                rigidbody = _player.rigidBody;
            playerFootsteps = AudioManager.instance.CreateInstance(FmodEvents.instance.playerFootsteps);
        }

        public override void UpdateLogic()
        {
            // Update IsRunning from input.
            IsRunning = canRun && Input.GetKey(runningKey);

            // Get targetMovingSpeed.
            float targetMovingSpeed = IsRunning ? runSpeed : speed;
            if (speedOverrides.Count > 0)
            {
                targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
            }

            // Get targetVelocity from input.
            Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

            // Apply movement.
            rigidbody.velocity = _player.transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);

            UpdateSound();
        }

        private void UpdateSound()
        {

            if (rigidbody.velocity.x != 0)
            {

                PLAYBACK_STATE playbackState;
                playerFootsteps.getPlaybackState(out playbackState);
                if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
                {
                    playerFootsteps.start();
                }
            }
            else
            {
                playerFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
            }
        }

        private void UseInput(Vector3 arg0)
        {
            
        }

        public override void Exit()
        {
            //_player.events.onMovementInput.RemoveListener(UseInput);
        }
    }
}
