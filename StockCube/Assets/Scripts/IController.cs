using System;
using System.Collections.Generic;

namespace StockCube
{
	public interface IController
	{
		StateMachine QuoteStateMachine 
		{
			get;
		}

		List<Quote> StockQuotes
		{
			get;
		}

		void PopulateStockQuotes();
	}
}