using UnityEngine;
using System;
using System.Collections.Generic;

namespace StockCube
{
	public abstract class FetchQuoteState : QuoteState
	{
		protected const string URL_PART_ONE = "http://finance.yahoo.com/webservice/v1/symbols/";
		protected const string URL_PART_TWO = "/quote?format=json&view=detail";

		protected WWW _www;
		protected string _url;
		protected string _jsonString;
		protected List<Quote> _quotes;

		//protected List<Quote> _quotes;

		public FetchQuoteState(Enum id, IController controller) : base(id, controller)
		{
			this._quotes = _main.StockQuotes;
		}
	}
}

