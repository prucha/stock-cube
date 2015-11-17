using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

namespace StockCube
{
	class StockCube : MonoBehaviour
	{
		public event EventHandler	CubeComplete;

		private GameObject		_quoteUI_Prefab;
		private GameObject 		_dummyUI_Prefab;

		private GameObject[] 	_GOquoteUIs = new GameObject[36];
		private GameObject[] 	_GOdummyUIs = new GameObject[18];

		private GameObject	_frontPlane;
		private GameObject	_rightPlane;
		private GameObject	_rearPlane;
		private GameObject	_leftPlane;
		private GameObject	_topPlane;
		private GameObject	_bottomPlane;

		//-----------------------------------

		private List<QuoteUI>	_quoteUIs;

		public List<QuoteUI> QuoteUIs
		{
			get { return _quoteUIs; }
			set { _quoteUIs = value; }
		}

		//-----------------------------------


		// Use this for initialization
		void Start () 
		{
			_quoteUI_Prefab = Resources.Load("Prefabs/QuoteUI") as GameObject;
			_dummyUI_Prefab = Resources.Load("Prefabs/DummyUI") as GameObject;
			
			_quoteUIs = new List<QuoteUI>();
			List<Vector3> panelPos = new List<Vector3>();


			//-----------------------------------------
			// Front Plane
			//-----------------------------------------
			//top row
			panelPos.Add( new Vector3(-35f, 35f, 50f) );
			panelPos.Add( new Vector3(0f, 35f, 50f) );
			panelPos.Add( new Vector3(35f, 35f, 50f) );
			
			//middle row
			panelPos.Add( new Vector3(-35f, 0f, 50f) );
			panelPos.Add( new Vector3(0f, 0f, 50f) );
			panelPos.Add( new Vector3(35f, 0f, 50f) );
			
			//botton row
			panelPos.Add( new Vector3(-35f, -35f, 50f) );
			panelPos.Add( new Vector3(0f, -35f, 50f) );
			panelPos.Add( new Vector3(35f, -35f, 50f) );
			
			//------------------------------------------

			_frontPlane = new GameObject();
			_frontPlane.name = "FrontPlane";
			_frontPlane.transform.position = new Vector3(0f,0f,50f);
			
			for (int i=0; i < 9; i++) 
			{
				_GOquoteUIs[i] = GameObject.Instantiate( _quoteUI_Prefab, panelPos[i], Quaternion.identity) as GameObject;
				_GOquoteUIs[i].transform.parent = _frontPlane.transform;
			}
			
			//------------------------------------------
			
			_rightPlane = new GameObject();
			_rightPlane.name = "RightPlane";
			_rightPlane.transform.position = new Vector3(0f,0f,50f);
			
			for (int i=0; i < 9; i++) 
			{
				_GOquoteUIs[(i+9)] = GameObject.Instantiate( _quoteUI_Prefab, panelPos[i], Quaternion.identity) as GameObject;
				_GOquoteUIs[(i+9)].transform.parent = _rightPlane.transform;
			}
			
			_rightPlane.transform.Translate(55f, 0f, 0f);
			_rightPlane.transform.Rotate(0f, 90f , 0f, Space.World);
			_rightPlane.transform.Translate(55f, 0f, 0f);
			
			//------------------------------------------
			
			_leftPlane = new GameObject();
			_leftPlane.name = "LeftPlane";
			_leftPlane.transform.position = new Vector3(0f,0f,50f);
			
			for (int i=0; i < 9; i++) 
			{
				_GOquoteUIs[(i+18)] = GameObject.Instantiate( _quoteUI_Prefab, panelPos[i], Quaternion.identity) as GameObject;
				_GOquoteUIs[(i+18)].transform.parent = _leftPlane.transform;
			}
			
			_leftPlane.transform.Translate(-55f, 0f, 0f);
			_leftPlane.transform.Rotate(0f, -90f , 0f, Space.World);
			_leftPlane.transform.Translate(-55f, 0f, 0f);
			
			//------------------------------------------
			
			_rearPlane = new GameObject();
			_rearPlane.name = "BehindPlane";
			_rearPlane.transform.position = new Vector3(0f,0f,50f);
			
			for (int i=0; i < 9; i++) 
			{
				_GOquoteUIs[(i+27)] = GameObject.Instantiate( _quoteUI_Prefab, panelPos[i], Quaternion.identity) as GameObject;
				_GOquoteUIs[(i+27)].transform.parent = _rearPlane.transform;
			}
			
			_rearPlane.transform.Translate(0f, 0f, -110f);
			_rearPlane.transform.Rotate(0f, 180f , 0f, Space.World);
			
			//------------------------------------------
			
			_topPlane = new GameObject();
			_topPlane.name = "TopPlane";
			_topPlane.transform.position = new Vector3(0f,0f,50f);
			
			for (int i=0; i < 9; i++) 
			{
				_GOdummyUIs[i] = GameObject.Instantiate( _dummyUI_Prefab, panelPos[i], Quaternion.identity) as GameObject;
				_GOdummyUIs[i].transform.parent = _topPlane.transform;
			}
			
			_topPlane.transform.Translate(0f, 55f, 0f);
			_topPlane.transform.Rotate(-90f, 0f , 0f, Space.World);
			_topPlane.transform.Translate(0f, 55f, 0f);
			
			//------------------------------------------
			
			_bottomPlane = new GameObject();
			_bottomPlane.name = "TopPlane";
			_bottomPlane.transform.position = new Vector3(0f,0f,50f);
			
			for (int i=0; i < 9; i++) 
			{
				_GOdummyUIs[(i+9)] = GameObject.Instantiate( _dummyUI_Prefab, panelPos[i], Quaternion.identity) as GameObject;
				_GOdummyUIs[(i+9)].transform.parent = _bottomPlane.transform;
			}
			
			_bottomPlane.transform.Translate(0f, -55f, 0f);
			_bottomPlane.transform.Rotate(-90f, 0f , 0f, Space.World);
			_bottomPlane.transform.Translate(0f, 55f, 0f);
			
			//------------------------------------------
			
			foreach (GameObject go in _GOquoteUIs) 
			{	
				Text[] texts;
				texts = go.GetComponentsInChildren<Text>();
				
				Image[] images; //There should be 2 arrow images to indicate stock loss/gain
				images = go.GetComponentsInChildren<Image>();
				
				_quoteUIs.Add( new QuoteUI(texts, images) );
				
				//Debug.Log(">>> _quoteUIs.Count: " + _quoteUIs.Count);	 
			}
			
			for (int i=9; i < 18; i++) 
			{
				Color color = new Color (0.7f, 1.0f, 0.7f, 0.5f);
				_quoteUIs[i].Panel.color = color;
			}
			
			for (int i=18; i < 27; i++) 
			{
				Color color = new Color (0.7f, 0.7f, 1.0f, 0.5f);
				_quoteUIs[i].Panel.color = color;
			}
			
			for (int i=27; i < 36; i++) 
			{
				Color color = new Color (1.0f, 1.0f, 0.7f, 0.5f);
				_quoteUIs[i].Panel.color = color;
			}
			
			
			uint dummyIndex = 0;
			foreach (GameObject go in _GOdummyUIs) 
			{	
				Image[] images; //There should be 2 arrow images to indicate stock loss/gain
				images = go.GetComponentsInChildren<Image>();
				
				Color color;
				
				if(dummyIndex < 9)
				{
					color = new Color(1.0f, 0.8f, 0.7f, 0.5f);
				}
				else
				{
					color = new Color(1.0f, 0.7f, 0.7f, 0.5f);
				}
				
				images[0].color = color;
				dummyIndex++;
			}
			
			//-------------------------------------------
			
			_frontPlane.transform.parent = this.transform;
			_rightPlane.transform.parent = this.transform;
			_leftPlane.transform.parent = this.transform;
			_rearPlane.transform.parent = this.transform;
			_topPlane.transform.parent = this.transform;
			_bottomPlane.transform.parent = this.transform;
			
			Debug.Log("[SF] Main::InitQuoteUIs() - _GOquoteUIs.Length: " + _GOquoteUIs.Length);
			this.CubeComplete(this, EventArgs.Empty );
		}



		public void PopulateQuotePanels(List<Quote> quotes)
		{
			for (int i=0; i < quotes.Count; i++) 
			{
				_quoteUIs[i].Name.text = quotes[i].Name;
				_quoteUIs[i].Price.text = "Price: " + quotes[i].Price;
				_quoteUIs[i].Symbol.text = "Symbol: " + quotes[i].Symbol;
				_quoteUIs[i].Volume.text = "Volume: " + quotes[i].Volume;
				_quoteUIs[i].Change.text = "Change: " + quotes[i].Change;
				_quoteUIs[i].ChangePercent.text = "Percent: " + quotes[i].ChangePercent;


                if(quotes[i].Change > 0)
                {
                    _quoteUIs[i].UpArrow.enabled = true;
                    _quoteUIs[i].DownArrow.enabled = false;
                }
                else if (quotes[i].Change < 0)
                {
                    _quoteUIs[i].UpArrow.enabled = false;
                    _quoteUIs[i].DownArrow.enabled = true;
                }
                else
                {
                    _quoteUIs[i].UpArrow.enabled = false;
                    _quoteUIs[i].DownArrow.enabled = false;
                }
			}
		}
		
		// Update is called once per frame
		void Update () 
		{
		
		}
	}
}
