using UnityEngine;
using System;

namespace StockCube
{
	public class FetchFinanceQuoteState : FetchQuoteState
	{
		public FetchFinanceQuoteState(Enum id, MonoBehaviour monoBehaviour) : base(id, monoBehaviour)
		{
			this._jsonString = "GS,USB,BK,C,V,WFC,JPM,DB,FITB";
			this._url = URL_PART_ONE + _jsonString + URL_PART_TWO;
		}
		
		public override void Enter()
		{			
			Debug.Log("-> FetchFinanceQuoteState::Enter()");	
			_www = new WWW( _url );	
		}
		
		public override void Update()
		{
			//Debug.Log("-> FetchFinanceQuoteState::Update()");
			
			if(_www.isDone) 
			{
				_quotes.AddRange( QuoteFactory.BuildYahooQuotes( _www.text ) ); 
				_stateMachine.ChangeState( QuoteStateId.IDLE );
			}
		}
		
		public override void Exit()
		{
			Debug.Log("-> FetchFinanceQuoteState::Exit()");
			_www = null;
			_main.PopulateStockQuotes();
		}
	}
}

