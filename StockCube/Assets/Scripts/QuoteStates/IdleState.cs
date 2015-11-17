using UnityEngine;
using System;

namespace StockCube
{
	public class IdleState : State
	{
		//--------------------------------
		// Methods
		//--------------------------------
		
		public IdleState(Enum id, MonoBehaviour monoBehaviour) : base(id, monoBehaviour)
		{

		}
		
		public override void Enter()
		{			
			Debug.Log("[SF] IdleState::Enter()");		
		}

		public override void Update()
		{
//			Debug.Log("[SF] IdleState::Update()");
		}
		
		public override void Exit()
		{
			Debug.Log("[SF] IdleState::Exit()");
		}
	}
}

