using UnityEngine;
using System;

namespace StockCube
{
	public class FetchHealthQuoteState : FetchQuoteState
	{
		public FetchHealthQuoteState(Enum id, MonoBehaviour monoBehaviour) : base(id, monoBehaviour)
		{
			this._jsonString = "PFE,AZN,CELG,NVS,ABC,BSX,CI,EW,HUM";
			this._url = URL_PART_ONE + _jsonString + URL_PART_TWO;
		}
		
		public override void Enter()
		{			
			Debug.Log("-> FetchHealthQuoteState::Enter()");	
			_www = new WWW( _url );	
		}
		
		public override void Update()
		{
			//Debug.Log("-> FetchHealthQuoteState::Update()");
			
			if(_www.isDone) 
			{
				_quotes.AddRange( QuoteFactory.BuildYahooQuotes( _www.text ) ); 
				_stateMachine.ChangeState( QuoteStateId.FETCH_ENERGY_QUOTES );
			}
		}
		
		public override void Exit()
		{
			Debug.Log("-> FetchHealthQuoteState::Exit()");
			_www = null;
		}
	}
}

