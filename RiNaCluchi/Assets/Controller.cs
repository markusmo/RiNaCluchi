using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Controller : MonoBehaviour
{
		
		RunwayController[] runWayControllers = new RunwayController[4];
		// Use this for initialization
		void Start ()
		{
				runWayControllers [0] = (RunwayController)GameObject.FindGameObjectWithTag ("runway1").GetComponent<RunwayController> ();
				runWayControllers [1] = (RunwayController)GameObject.FindGameObjectWithTag ("runway2").GetComponent<RunwayController> ();
				runWayControllers [2] = (RunwayController)GameObject.FindGameObjectWithTag ("runway3").GetComponent<RunwayController> ();
				runWayControllers [3] = (RunwayController)GameObject.FindGameObjectWithTag ("heliplatform").GetComponent<RunwayController> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				
		}

		void OnGUI ()
		{
		}

		private int MAX_ROUNDS = 100;
		private bool GAME_END = false;

		public void EndRound ()
		{
				if (MAX_ROUNDS-- <= 0) {
						GAME_END = true;
						return;
				}
				CalculateRound ();
				GenerateEventsForNextRound ();
		}

		private HandFieldController _hand;
		private RunwayCardField _runwayTo;
		private RunwayCardField _runwayFrom;

		public void GetCardFromHand (HandFieldController hand)
		{
				this._hand = hand;
		}

		public void GetCardFromRunway (RunwayCardField runway)
		{
				this._runwayFrom = runway;
		}

		public void PlaceCardInRunway (RunwayCardField runway)
		{
				
				this._runwayTo = runway;
				if (_runwayTo.IsFree) {
					Debug.Log ("placeCard");
						if (this._hand == null && this._runwayFrom != null) {
								_runwayTo.TheCard = _runwayFrom.TakeCard();
								_runwayTo = null;
								_runwayFrom = null;
						} else if (_runwayFrom == null && this._hand != null) {
								_runwayTo.TheCard = _hand.TakeCard ();
								_hand = null;
								_runwayTo = null;
						}
				}
				else
				{
					Debug.Log("Full Runway");
				}
		}

		private void CalculateRound ()
		{
				foreach (var runWay in runWayControllers) {
						runWay.Aircraft.TheAircraft.Cleanlyness -= runWay.Fields.getCleanSkill ();
						runWay.Aircraft.TheAircraft.Maintenance -= runWay.Fields.getMaintenanceSkill ();
						if (runWay.Aircraft.TheAircraft.Cleanlyness <= 0 && runWay.Aircraft.TheAircraft.Maintenance <= 0) {
								runWay.Aircraft.DriveIntoHangar ();
						}
				}
		}

		private void GenerateEventsForNextRound ()
		{
			
		}
}
