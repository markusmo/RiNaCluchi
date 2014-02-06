using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class RunwayCardField : MonoBehaviour
{
	
		private Controller _controller;
		// Use this for initialization
		void Start ()
		{
				_controller = GameObject.FindGameObjectWithTag ("controller").GetComponent<Controller> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		private Card _theCard;
	
		public void PlaceCard (Card card)
		{
				this._theCard = card;
		}
	
		public Card TakeCard ()
		{
				if (!IsFree ()) {
						Card tmp = this._theCard.Clone ();
						this._theCard = null;
						return tmp;
				}
				return null;
		}

		public Card TheCard {
				get{ return this._theCard;}
				private	set{ this._theCard = value;}
		}

		public bool IsFree ()
		{
				return this._theCard == null;
		}
	
		void OnMouseDown ()
		{

				if (this._theCard != null) {
						_controller.GetCardFromRunway (this);
						Debug.Log (_theCard.GetType ());
				} else {
						
				}
		}

		void OnMouseOver ()
		{	
				if (Input.GetMouseButtonDown (1)) {
						_controller.PlaceCardInRunway (this);				
				}
		}
}

