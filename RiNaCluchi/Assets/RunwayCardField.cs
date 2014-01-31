using UnityEngine;
using System.Collections;
using AssemblyCSharp;
public class RunwayCardField : MonoBehaviour {
	
	private Controller _controller;
	// Use this for initialization
	void Start () {
		_controller = GameObject.FindGameObjectWithTag ("controller").GetComponent<Controller> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private Card _theCard;
	
	public Card TheCard {
		get{ return _theCard;}
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
			Card tmp = this.TheCard.Clone ();
			this.TheCard = null;
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
			_controller.GetCardFromRunway(this);
			Debug.Log(_theCard.GetType());
		}else{
			_controller.PlaceCardInRunway(this);
		}
	}
}
