using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class StackController : MonoBehaviour
{

		private Controller _controller;
		HandController handController;
		// Use this for initialization
		void Start ()
		{
				_controller = GameObject.FindGameObjectWithTag ("controller").GetComponent<Controller> ();
				handController = GameObject.FindGameObjectWithTag ("hand").GetComponent<HandController> ();
		}
	
		// Update is called once per frame
		void Update ()
		{

		}

		void OnMouseDown ()
		{
				if (_controller.ActualRound.Draws-- > 0) {		
						handController.PlaceCard (RandomCardGenerator.Instance.GenerateElement ());
				}
		}
}
