using UnityEngine;
using System.Collections;

public class RoundController : MonoBehaviour {

	private Controller _controller;
	
	// Use this for initialization
	void Start ()
	{
		_controller = GameObject.FindGameObjectWithTag ("controller").GetComponent<Controller> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		_controller.EndRound();
	}
}
