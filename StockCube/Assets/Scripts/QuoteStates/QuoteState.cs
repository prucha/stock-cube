using UnityEngine;
using System;

namespace StockCube
{
	public abstract class QuoteState : State<Enum>
	{
		protected StateMachine<Enum>		_stateMachine;
		protected string			        _nextStateId;
		protected IController 	            _main;

		public QuoteState(Enum id, IController controller) : base(id, controller.QuoteStateMachine)
		{
			this._main = controller as IController;	
			this._stateMachine = _main.QuoteStateMachine;
		}
	}
}

