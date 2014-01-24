using UnityEngine;
using System.Collections;
using AssemblyCSharp;
public class HandController : MonoBehaviour {

	private static int  MAX_CARDS = 12;

	int _actualCards = -1;
	private Card[] cards = new Card[MAX_CARDS];

	private bool handFull = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeCard(Card card)
	{
		if(_actualCards < MAX_CARDS-1){
			this.cards[++_actualCards] = card;
		}else{
			handFull = true;
		}
		Debug.Log("Take" +_actualCards);
	}

	void OnGui()
	{
		if(handFull){
			GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
			GUILayout.FlexibleSpace();
			
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUIStyle style = new GUIStyle();
			style.fontSize = 40	;
			GUILayout.Label("Start a new Game",style);
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			bool pressed = GUILayout.Button("Start");
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			
			GUILayout.FlexibleSpace();
			GUILayout.EndArea();
			if(pressed)
			{
				Debug.Log ("Pressed Start");
				this.SendMessage("OnGameStart",SendMessageOptions.RequireReceiver);
			}
		}

	}
}
