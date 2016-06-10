using System;

namespace StockCube
{
	public interface IState<T>
	{
		T ID { get; }

		void Enter();
		void Update();
		void Exit();
	}
}


