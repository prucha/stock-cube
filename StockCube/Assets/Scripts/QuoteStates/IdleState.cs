using UnityEngine;
using System;

namespace StockCube
{
	public class IdleState : QuoteState
	{
		//--------------------------------
		// Methods
		//--------------------------------
		
		public IdleState(Enum id, IController controller) : base(id, controller)
		{

		}
		
		public override void Enter()
		{			
			Debug.Log("-> IdleState::Enter()");		
		}

		public override void Update()
		{
//			Debug.Log("-> IdleState::Update()");
		}
		
		public override void Exit()
		{
			Debug.Log("-> IdleState::Exit()");
		}
	}
}

