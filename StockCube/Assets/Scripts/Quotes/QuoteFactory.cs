using System;
using System.Collections.Generic;
using System.Collections;
using MiniJSON;
using UnityEngine;

namespace StockCube
{
	static class QuoteFactory
	{	
		public static List<Quote> BuildYahooQuotes(string json)
		{	
			List<Quote> quotes = new List<Quote> ();
			Dictionary<string, object> dict;
			List<object> resources;

			Dictionary<string, object> resource;
			Dictionary<string, object> fields;
			
			dict = Json.Deserialize( json ) as Dictionary<string,object>;

			if (!dict.ContainsKey("list")) 
			{
				Debug.LogWarning("[SF] QuoteFactory::BuildYahooQuotes() - 'list' Key not found!");  
				return null;
			}

			dict = dict["list"] as Dictionary<string,object>;

			//--------------------------------------------------

			if (!dict.ContainsKey("resources")) 
			{
				Debug.LogWarning("[SF] QuoteFactory::BuildYahooQuotes() - 'resources' Key not found!");  
				return null;
			}

			resources = dict["resources"] as List<object>;

			dict = resources[0] as Dictionary<string, object>;

			//--------------------------------------------------

			foreach (Dictionary<string,object> res in resources)
			{
				if (!res.ContainsKey("resource")) 
				{
					Debug.LogWarning("[SF] QuoteFactory::BuildYahooQuotes() - 'resource' Key not found!");  
					return null;
				}

				resource = res["resource"] as Dictionary<string, object>;

				//----------------------

				if(!resource.ContainsKey("fields") )
				{
					Debug.LogWarning("[SF] QuoteFactory::BuildYahooQuotes() - 'fields' Key not found!"); 
					return null;
				}
				
				fields = resource["fields"] as Dictionary<string,object>;

				quotes.Add( new Quote( fields ) );
			}

			return quotes;
		}

	}
}

