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
	
		public Card TheCard {
				get{ return _theCard;}
				set {
						if (IsFree) {
								_theCard = value;
								this.IsFree = false;
						}
				}
		}
	
		public Card TakeCard ()
		{
				if (!IsFree) {
						Card tmp = this.TheCard.Clone ();
						this._theCard = null;
						this.IsFree = true;
						return tmp;
				}
				return null;
		}

		private bool isFree = true;

		public bool IsFree {
				get{ return isFree;}
				private set{ isFree = value;}
		}
	
		void OnMouseDown ()
		{
				if (this._theCard != null) {
						_controller.GetCardFromRunway (this);
						Debug.Log (_theCard.GetType ());
				} else {
						_controller.PlaceCardInRunway (this);
				}
		}
}
