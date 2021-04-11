   
public abstract class State
    {
        protected Unit character;

        public abstract void Tick();

        public virtual void OnStateEnter() { }
        public virtual void OnStateExit() { }

        public State(Unit character)
        {
            this.character = character;
        }
    }
