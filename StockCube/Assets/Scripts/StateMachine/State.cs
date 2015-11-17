using System;
using UnityEngine;

namespace StockCube
{
	public class State : IState
	{
        protected Enum _id;
        protected MonoBehaviour _monoBehaviour;
		
		public Enum ID 
		{
			get { return _id; }
		}

		public State(Enum id, MonoBehaviour monoBehaviour)
		{
			this._id = id;
			this._monoBehaviour = monoBehaviour;
		}
		
		public virtual void Enter() {}
		public virtual void Update() {}
		public virtual void Exit() {}
	}
}

