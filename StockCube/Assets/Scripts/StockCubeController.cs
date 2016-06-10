using UnityEngine;
using System.Collections.Generic;
using System;
using System.Timers;


namespace StockCube
{
    public enum QuoteStateId
    {
        IDLE,

        RESET_QUOTES,
        FETCH_TECH_QUOTES,
        FETCH_HEALTH_QUOTES,
        FETCH_ENERGY_QUOTES,
        FETCH_FINANCE_QUOTES
    }


    public class StockCubeController : MonoBehaviour, IController
    {
        private GameObject      _stockCubeObj;
        private StockCube       _stockCube;

        private StateMachine<Enum>    _quoteStateMachine;
        private List<Quote>     _stockQuotes;

        private Timer           _timer;
        private bool            _fetchNewQuotes = false;


        //-----------------------------------------------
        // Accessors
        //-----------------------------------------------

        public StateMachine<Enum> QuoteStateMachine
        {
            get { return _quoteStateMachine; }
        }

        public List<Quote> StockQuotes
        {
            get { return _stockQuotes; }
        }


        //-----------------------------------------------
        // Methods
        //-----------------------------------------------

        void Awake()
        {
            Debug.Log("-> StockCubeCtrl::Awake()");
            this._stockQuotes = new List<Quote>();

            InitStateMachine();
            InitStockCube();
        }


        void InitStateMachine()
        {
            this._quoteStateMachine = new StateMachine<Enum>();

            this._quoteStateMachine.AddState(new IdleState(QuoteStateId.IDLE, this));
            this._quoteStateMachine.AddState(new FetchTechQuoteState(QuoteStateId.FETCH_TECH_QUOTES, this));
            this._quoteStateMachine.AddState(new FetchHealthQuoteState(QuoteStateId.FETCH_HEALTH_QUOTES, this));
            this._quoteStateMachine.AddState(new FetchEnergyQuoteState(QuoteStateId.FETCH_ENERGY_QUOTES, this));
            this._quoteStateMachine.AddState(new FetchFinanceQuoteState(QuoteStateId.FETCH_FINANCE_QUOTES, this));

            this._quoteStateMachine.ChangeState(QuoteStateId.IDLE);
        }


        void InitStockCube()
        {
            _stockCubeObj = new GameObject();
            _stockCubeObj.name = "StockCube";
            _stockCube = _stockCubeObj.AddComponent<StockCube>();

            _timer = new Timer(3000);
            _timer.Elapsed += new ElapsedEventHandler(OnTimerElapsed);
            _timer.AutoReset = true;
            _timer.Enabled = true;
            _timer.Stop();

            _stockCube.CubeComplete += OnCubeComplete;
        }


        void Start()
        {
            Debug.Log("-> StockCubeCtrl::Start()");
        }


        void Update()
        {
            if (Input.GetKey("escape"))
            { //Make sure we can quit this App
                Application.Quit();
            }

            this._quoteStateMachine.Update();

            if (_fetchNewQuotes)
            {
                _fetchNewQuotes = false;
                _timer.Stop();
                this._quoteStateMachine.ChangeState(QuoteStateId.FETCH_TECH_QUOTES);
            }
        }


        public void PopulateStockQuotes()
        {
            _stockCube.PopulateQuotePanels(_stockQuotes);
            _timer.Start();
        }

        //-----------------------------------------------------
        // EventHandlers
        //-----------------------------------------------------

        public void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            //this.QuoteStateMachine.ChangeState( QuoteStateId.FETCH_TECH_QUOTES );
            _fetchNewQuotes = true;
        }


        public void OnCubeComplete(object sender, EventArgs args)
        {
            Debug.Log("-> StockCubeCtrl::OnCubeComplete()");
            _fetchNewQuotes = true;
            //this.QuoteStateMachine.ChangeState( QuoteStateId.FETCH_TECH_QUOTES );
        }


        public void OnRequestQuotesButton()
        {
            Debug.Log("-> StockCubeCtrl::OnRequestQuotesButton()");
            _fetchNewQuotes = true;
            //this.QuoteStateMachine.ChangeState( QuoteStateId.FETCH_TECH_QUOTES );
        }
    }
}