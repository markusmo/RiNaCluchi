using UnityEngine;
using System.Collections;
using AssemblyCSharp;
public class HandController : MonoBehaviour {

	private static int  MAX_CARDS = 12;

	int _actualCards = -1;
	private HandFieldController[] cards = new HandFieldController[MAX_CARDS];

	private bool handFull = false;
	private bool pressed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeCard(Card card)
	{
		if(_actualCards < MAX_CARDS-1){
			HandFieldController c = cards[++_actualCards];
			Debug.Log(c);
			if(this.cards[_actualCards] == null)
			{
				this.cards[_actualCards] = (HandFieldController)GameObject.FindGameObjectWithTag("hand"+(_actualCards+1)).GetComponent<HandFieldController>();
				Debug.Log("null");
			}
			this.cards[_actualCards].TheCard = card;	
			Debug.Log("Take " +_actualCards);
			handFull = false;
		}else{
			handFull = true;
		}	
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
