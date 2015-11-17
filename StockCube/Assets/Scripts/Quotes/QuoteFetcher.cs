using System.IO;
using System.Net;
using System;
using UnityEngine;


namespace StockCube
{
	static class QuoteFetcher
	{
		public static string FetchYahooQuote(string symbol)
		{			
			string data = "";
			string url = "http://finance.yahoo.com/webservice/v1/symbols/" + symbol + "/quote?format=json&view=detail";
			
			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				Stream stream = response.GetResponseStream();
				StreamReader reader = new StreamReader(stream);
				data = reader.ReadToEnd();
				
				reader.Close();
				stream.Close();
			}
			catch(Exception e)
			{
                Debug.LogError("-> QuoteFetcher::FetchYahooQuote( " + symbol + " ) - " + e.Message );
			}
			
			return data;
		}
	}
}

