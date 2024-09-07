using StateMachine;

namespace Assets.Scripts.Entity.Player.Movement.States
{
    [System.Serializable]
    public class Freeze : BaseState
    {
        public Freeze(string name, StateMachine.StateMachine stateMachine) : base(name, stateMachine)
        {

        }
    }
}
