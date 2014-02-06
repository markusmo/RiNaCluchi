using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class StackController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown()
	{
		HandController handController = GameObject.FindGameObjectWithTag("hand").GetComponent<HandController>();
		handController.PlaceCard(RandomCardGenerator.Instance.GenerateElement());
	}
}
