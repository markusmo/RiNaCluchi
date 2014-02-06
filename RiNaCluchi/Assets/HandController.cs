using UnityEngine;
using System.Collections;
using AssemblyCSharp;
public class HandController : MonoBehaviour {

	private static int  MAX_CARDS = 12;

	private HandFieldController[] cards = new HandFieldController[MAX_CARDS];

	private bool handFull = false;
	private bool pressed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaceCard(Card card)
	{
		for (int i = 0; i < MAX_CARDS; i++) {	
			if(this.cards[i] == null)
			{
				this.cards[i] = (HandFieldController)GameObject.FindGameObjectWithTag("hand"+(i+1)).GetComponent<HandFieldController>();
				Debug.Log("null");
			}
			if(this.cards[i].IsFree)
			{
				this.cards[i].TheCard = card;	
				Debug.Log("Place " +i);
				handFull = false;
				return;
			}
		}
		handFull = true;
	}

	void OnGUI()
	{
		if(handFull && !pressed){
			Debug.Log("Handfull");
			GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
			GUILayout.FlexibleSpace();
			
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUIStyle style = new GUIStyle();
			style.fontSize = 40	;
			GUILayout.Label("Hand full!",style);
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			pressed = GUILayout.Button("OK");
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			
			GUILayout.FlexibleSpace();
			GUILayout.EndArea();
		}

	}
}
