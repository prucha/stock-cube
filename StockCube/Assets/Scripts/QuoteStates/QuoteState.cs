using UnityEngine;
using System;

namespace StockCube
{
	public class QuoteState : State
	{
		protected StateMachine		_stateMachine;
		protected string			_nextStateId;
		protected IController 	_main;

		public QuoteState(Enum id, MonoBehaviour monoBehaviour) : base(id, monoBehaviour)
		{
			this._main = monoBehaviour as IController;	
			this._stateMachine = _main.QuoteStateMachine;
		}
	}
}

