//Finite State Machine
using UnityEngine;
using System.Collections.Generic;
using System;

namespace StockCube
{
	public class StateMachine
	{
		protected IState                        _currentState;		
		protected Dictionary<Enum, IState>    _states;
				
		public IState CurrentState 
		{
			get{ return _currentState; }
		}
				
		//------------------------
		// Methods
		//------------------------
		
		public StateMachine ()
		{
			_currentState = null;
			_states = new Dictionary<Enum, IState>();				
		}
			
        	
		public void Update()
		{
			if(_currentState != null)
				_currentState.Update();
		}
		
        			
		public void AddState( IState state )
		{
			Debug.Log("[] StateMachine::AddState() - state ID: " + state.ID);
			this._states.Add( state.ID, state );
		}
		
		
		public bool ChangeState(IState state)
		{ 
			if(state != null)
			{
				if(_currentState != null)
				{
				 	_currentState.Exit();
				}

				_currentState = state;
				_currentState.Enter();
				
				return true;
			}
			else
			{
				return false;
			}
		}
		

		public bool ChangeState(Enum stateID)
		{			
			if (_currentState != null && stateID == _currentState.ID) {
				return true;
			} 
			
			return ChangeState( _states[stateID] );
		}
	}
}

