using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Controller : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		private HandFieldController _hand;
		private RunwayCardField _runwayTo;
		private RunwayCardField _runwayFrom;

		public void GetCardFromHand (HandFieldController hand)
		{
				this._hand = hand;
		}

		public void GetCardFromRunway (RunwayCardField runway)
		{
				this._runwayFrom = runway;
		}

		public void PlaceCardInRunway (RunwayCardField runway)
		{
				Debug.Log ("placeCard");
				this._runwayTo = runway;
			
				if (this._hand == null && this._runwayFrom != null) {
						_runwayTo.TheCard = _runwayFrom.TakeCard ();
						_runwayTo = null;
						_runwayFrom = null;
				} else if (_runwayFrom == null && this._hand != null) {
						_runwayTo.TheCard = _hand.TakeCard ();
						_hand = null;
						_runwayTo = null;
		}
		}
}
