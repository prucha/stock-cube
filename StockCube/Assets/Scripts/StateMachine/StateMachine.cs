//Finite State Machine
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace StockCube
{
	public class StateMachine<T> : IStateMachine<T>
	{
		protected IState<T> _currentState;
		protected IState<T> _prevState;

		protected Dictionary<T, IState<T>> _states;
		
				
		public IState<T> CurrentState 
		{
			get{ return _currentState; }
		}

		public IState<T> PreviousState
		{
			get{ return _prevState; }
		}
				
		//------------------------
		// Methods
		//------------------------
		
		public StateMachine ()
		{
			_currentState = null;
			_states = new Dictionary<T, IState<T>>();				
		}
				
		public void Update()
		{
            if (_currentState != null)
            {
                _currentState.Update();
            }
		}

        public void AddState( IState<T> state )
		{
			Debug.Log("-> StateMachine::AddState() - state ID: " + state.ID);
			this._states.Add( state.ID, state );
		}
		
		//-------------------------------------------
		
        public bool ChangeState(IState<T> state)
        {

            if (state != null)
            {
                if (_currentState != null)
                    _currentState.Exit();

                _prevState = _currentState;
                _currentState = state;
                _currentState.Enter();
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool ChangeState(T stateID)
        {
            if (_currentState != null)
            {
                //although we are trying to change to the what is already the current state.
                //this is, after all, the state that we want, so lets return true.
                if (stateID.Equals(_currentState.ID))
                    return true;
            }

            return ChangeState(_states[stateID]);
        }
    }
}


