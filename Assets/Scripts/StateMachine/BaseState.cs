namespace StateMachine {
    public class BaseState {
        public string name;

        protected StateMachine _stateMachine;

        public BaseState(string name, StateMachine stateMachine) {
            this.name = name;
            _stateMachine = stateMachine;
        }

        public virtual void Enter() { }
        public virtual void UpdateLogic() { }
        public virtual void UpdatePhysics() { }
        public virtual void Exit() { }
        public virtual void UpdateAnimator() { }
    }
}
