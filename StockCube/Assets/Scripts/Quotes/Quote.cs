using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockCube
{
	/// <summary>
	/// Simple Stock object class used to transfer data from XML file to the Data-table
	/// </summary>
	public class Quote
	{ 
		private string _name;
		private double _price;
		private string _symbol;
		private string _ts;
		private string _type;
		private string _utctime;
		private int _volume;

		//'detail' fields 
		private double	_change;
		private double	_changePercent; 

		private double	_dayHigh;
		private double _dayLow;
		private double _yearHigh;
		private double _yearLow;

		//----------------------------------------------

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public double Price
		{
			get { return _price; }
			set { _price = value; }
		}

		public string Symbol
		{
			get { return _symbol; }
			set { _symbol = value; }
		}

		public string TS
		{
			get { return _ts; }
			set { _ts = value; }
		}

		public string Type
		{
			get { return _type; }
			set { _type = value; }
		}

		public string UTCTime
		{
			get { return _utctime; }
			set { _utctime = value; }
		}

		public int Volume
		{
			get { return _volume; }
			set { _volume = value; }
		}


		//-----------------------------------
		//'detail' Properties
		//-----------------------------------
		public double Change
		{
			get { return _change; }
			set { _change = value; }
		}

		public double ChangePercent
		{
			get { return _changePercent; }
			set { _changePercent = value; }
		}

		public double DayHigh
		{
			get { return _dayHigh; }
			set { _dayHigh = value; }
		}

		public double DayLow
		{
			get { return _dayLow; }
			set { _dayLow = value; }
		}

		public double YearHigh
		{
			get { return _yearHigh; }
			set { _yearHigh = value; }
		}
		
		public double YearLow
		{
			get { return _yearLow; }
			set { _yearLow = value; }
		}


		//--------------------------------------------
		// Methods
		//--------------------------------------------
		public Quote(Dictionary<string,object> dict)
		{

			_name		= string.Empty;
			_price 		= 0;
			_symbol		= string.Empty;
			_ts			= string.Empty;
			_type		= string.Empty;
			_utctime	= string.Empty;
			_volume		= 0;

			_change = 0;
			_changePercent = 0;
			_dayHigh = 0;
			_dayLow = 0;
			_yearHigh = 0;
			_yearLow = 0;




			if (dict.ContainsKey("name") && dict["name"] != null) 
			{
				_name = dict["name"].ToString();
			}

			if (dict.ContainsKey("price") && dict["price"] != null) 
			{
				_price = Convert.ToDouble( dict["price"] );
			}

			if (dict.ContainsKey("symbol") && dict["symbol"] != null) 
			{
				_symbol = dict["symbol"].ToString();
			}

			if (dict.ContainsKey("ts") && dict["ts"] != null) 
			{
				_ts = dict["ts"].ToString();
			}

			if (dict.ContainsKey("type") && dict["type"] != null) 
			{
				_type = dict["type"].ToString();
			}

			if (dict.ContainsKey("utctime") && dict["utctime"] != null) 
			{
				_utctime = dict["utctime"].ToString();
			}

			if (dict.ContainsKey("volume") && dict["volume"] != null) 
			{
				_volume = Convert.ToInt32( dict["volume"] );
			}

			//--------------------------

			if (dict.ContainsKey("change") && dict["change"] != null) 
			{
				_change = Convert.ToDouble( dict["change"] );
			}

			if (dict.ContainsKey("chg_percent") && dict["chg_percent"] != null) 
			{
				_changePercent = Convert.ToDouble( dict["chg_percent"] );
			}

			//---------

			if (dict.ContainsKey("day_high") && dict["day_high"] != null) 
			{
				_dayHigh = Convert.ToDouble( dict["day_high"] );
			}

			if (dict.ContainsKey("day_low") && dict["day_low"] != null) 
			{
				_dayLow = Convert.ToDouble( dict["day_low"] );
			}

			//---------

			if (dict.ContainsKey("year_high") && dict["year_high"] != null) 
			{
				_yearHigh = Convert.ToDouble( dict["year_high"] );
			}

			if (dict.ContainsKey("year_low") && dict["year_low"] != null) 
			{
				_yearLow = Convert.ToDouble( dict["year_low"] );
			}

			//---------
		}

		public override string ToString() 
		{
			string s = "";

			s += "NAME:    " + _name	+ "\t\t\t\t" + "SYMBOL:  " + _symbol + "\n";
			s += "PRICE:   " + _price  	+ "\t\t\t\t" + "VOLUME:  " + _volume + "\n";
		
			return s;
		}

	}
}
