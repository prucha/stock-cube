using System;

namespace StockCube
{
	public abstract class State<T> : IState<T>
	{
        protected T _id;
		protected IStateMachine<T> _stateMachine;

		protected T _nextStateId;
		protected T _backStateId;


		public T ID 
		{
			get { return _id; }
		}
		
		public State(T id, IStateMachine<T> stateMachine)
		{
			this._id = id;
			this._stateMachine = stateMachine;
		}

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();       
	}
}


