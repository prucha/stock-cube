using UnityEngine;
using System;

namespace StockCube
{
	public class FetchTechQuoteState : FetchQuoteState
	{
		public FetchTechQuoteState(Enum id, MonoBehaviour monoBehaviour) : base(id, monoBehaviour)
		{
			this._jsonString = "YHOO,AAPL,GOOG,TWTR,FB,IBM,INTC,ARMH,HPQ";
			this._url = URL_PART_ONE + _jsonString + URL_PART_TWO;
		}
		
		public override void Enter()
		{			
			Debug.Log("-> FetchTechQuoteState::Enter()");	
			_quotes.Clear();
			_www = new WWW( _url );	
		}
		
		public override void Update()
		{
			//Debug.Log("-> FetchTechQuoteState::Update()");

			if(_www.isDone) 
			{
				_quotes.AddRange( QuoteFactory.BuildYahooQuotes( _www.text ) ); 
				_stateMachine.ChangeState( QuoteStateId.FETCH_HEALTH_QUOTES );
			}
		}
		
		public override void Exit()
		{
			Debug.Log("-> FetchTechQuoteState::Exit()");
			_www = null;
		}
	}
}

