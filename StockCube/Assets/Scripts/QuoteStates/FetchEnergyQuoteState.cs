using UnityEngine;
using System;

namespace StockCube
{
	public class FetchEnergyQuoteState : FetchQuoteState
	{
		public FetchEnergyQuoteState(Enum id, MonoBehaviour monoBehaviour) : base(id, monoBehaviour)
		{
			this._jsonString = "ATW,XOM,SDLP,NRP,ALDW,GASS,CVX,REGI,TEP";
			this._url = URL_PART_ONE + _jsonString + URL_PART_TWO;
		}
		
		public override void Enter()
		{			
			Debug.Log("-> FetchEnergyQuoteState::Enter()");	
			_www = new WWW( _url );	
		}
		
		public override void Update()
		{
			//Debug.Log("-> FetchEnergyQuoteState::Update()");
			
			if(_www.isDone) 
			{
				_quotes.AddRange( QuoteFactory.BuildYahooQuotes( _www.text ) ); 
				_stateMachine.ChangeState( QuoteStateId.FETCH_FINANCE_QUOTES );
			}
		}
		
		public override void Exit()
		{
			Debug.Log("-> FetchEnergyQuoteState::Exit()");
			_www = null;
		}
	}
}

