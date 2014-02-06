using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class HandFieldController : MonoBehaviour
{
		private HandController handController;
		private Controller _controller;
		// Use this for initialization
		void Start ()
		{
				handController = GameObject.FindGameObjectWithTag ("hand").GetComponent<HandController> ();
				_controller = GameObject.FindGameObjectWithTag ("controller").GetComponent<Controller> ();
				Debug.Log (this.gameObject.tag);
				this.IsFree = true;
		}
		// Update is called once per frame
		void Update ()
		{
				this.renderer.enabled = !this.isFree;
		}

		private Card _theCard;

		public Card TheCard {
				private get{ return _theCard; }
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
						Debug.Log ("Take Card in Hand");
						Card tmp = this.TheCard.Clone ();
						this._theCard = null;
						this.isFree = true;
						return tmp;
				}
				return null;
		}

		private bool isFree = true;

		public bool IsFree {
				get{ return isFree; }
				private set{ isFree = value; }
		}

		void OnMouseDown ()
		{
				if (this._theCard != null) {
						_controller.GetCardFromHand (this);
						Debug.Log (_theCard.GetType ());
				}
		}

		void OnMouseOver ()
		{	
				GameObject obj = GameObject.FindGameObjectWithTag ("selectcard");
				Card c = this.TheCard;
				SpawnController.GetInstance ().ChangeCardTexture (obj, c);
		}
}
