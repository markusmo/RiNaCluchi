using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class HandFieldController : MonoBehaviour {
	private HandController handController;

	public HandFieldController ()
		{

		}
	// Use this for initialization
	void Start () {
		handController = GameObject.FindGameObjectWithTag("hand").GetComponent<HandController>();
		Debug.Log(this.gameObject.tag);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{

	}

	public Card Card {
		private get{return Card;}
		set{
			if(Free)
			{
				Card = value;
				this.Free = false;
			}
		}
	}
	public Card TakeCard()
	{
		if(!Free)
		{
			Card tmp = this.Card.Clone();
			this.Card = null;
			this.Free = true;
			return tmp;
		}
		return null;
	}

	public bool Free {
				get;
		private set;
		}

}
