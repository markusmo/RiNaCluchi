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
				this.Free = true;
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
		private Card _theCard;

		public Card TheCard {
				private get{ return _theCard;}
				set {
						if (Free) {
								_theCard = value;
								this.Free = false;
						}
				}
		}

		public Card TakeCard ()
		{
				if (!Free) {
						Debug.Log("Take Card in Hand");
						Card tmp = this.TheCard.Clone ();
						this._theCard = null;
						this.Free = true;
						return tmp;
				}
				return null;
		}

	private bool _free = true;
	public bool Free {
		get{return _free;}
		private set{_free = value;}
	}

		void OnMouseDown ()
		{
		if(this._theCard != null){
			_controller.GetCardFromHand(this);
			Debug.Log(_theCard.GetType());
		}
		}
}
