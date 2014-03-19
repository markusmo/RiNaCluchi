using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class AircraftPrediction : MonoBehaviour
{
		private string text;
		
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				this.guiText.text = text;
		}
		
		public void PredictAircraftEvent (string e)
		{
				this.text = e;
		}
}
