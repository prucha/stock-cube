using System;

namespace StockCube
{
    public interface IState
    {
        Enum ID
        {
            get;
        }

        void Enter();
        void Update();
        void Exit();

    }
}
