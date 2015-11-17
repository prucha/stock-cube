using System;
using UnityEngine;
using UnityEngine.UI;

namespace StockCube
{
	public class QuoteUI
	{
		public Text Name;
		public Text Symbol;
		public Text Price;
		public Text Volume;
		public Text Change;
		public Text ChangePercent;

		public Image UpArrow;
		public Image DownArrow;

		public Image Panel;
	
		public QuoteUI( Text[] texts, Image[] images )
		{
			this.Name 			= texts[0];
			this.Symbol 		= texts[1];
			this.Price 			= texts[2];
			this.Volume 		= texts[3];
			this.Change 		= texts[4];
			this.ChangePercent	= texts[5];

			// The Background Panel Occupies images[0]
			this.Panel 			= images[0];

			//var color = new Color (1.0f, 0.7f, 0.7f);
			//this.Panel.color = color;

			this.UpArrow 		= images[1];
			this.DownArrow 		= images[2];

			this.UpArrow.enabled = false;
			this.DownArrow.enabled = false;
		}
	}
}

