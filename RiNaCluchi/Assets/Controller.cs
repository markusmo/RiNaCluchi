using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System.Collections.Generic;

public class Controller : MonoBehaviour
{
		List<GameEvent> gameEvents = new List<GameEvent> ();
		RunwayController[] runWayControllers = new RunwayController[4];
		private static int MAX_ROUNDS = 100;
		private Round actualRound;

		public Round ActualRound {
				get{ return actualRound;}
				private set{ this.actualRound = value;}
		}
		// Use this for initialization
		void Start ()
		{
				runWayControllers [0] = (RunwayController)GameObject.FindGameObjectWithTag ("runway1").GetComponent<RunwayController> ();
				runWayControllers [1] = (RunwayController)GameObject.FindGameObjectWithTag ("runway2").GetComponent<RunwayController> ();
				runWayControllers [2] = (RunwayController)GameObject.FindGameObjectWithTag ("runway3").GetComponent<RunwayController> ();
				runWayControllers [3] = (RunwayController)GameObject.FindGameObjectWithTag ("heliplatform").GetComponent<RunwayController> ();
				this.actualRound = new Round (MAX_ROUNDS, 5); //First Round, 5 Draws;
		}
	
		// Update is called once per frame
		void Update ()
		{
				
		}

		void OnGUI ()
		{
		}

		private bool GAME_END = false;

		public void EndRound ()
		{
				if (this.actualRound.RoundNumber - 1 <= 0) {
						GAME_END = true;
						return;
				}
				CalculateRound ();
				GenerateEventsForNextRound ();
				this.actualRound = new Round (actualRound.RoundNumber - 1, 1);	
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
				if (_runwayTo.IsFree ()) {
						Debug.Log ("placeCard");
						if (this._hand == null && this._runwayFrom != null) {
								_runwayTo.PlaceCard (_runwayFrom.TakeCard ());
								_runwayTo = null;
								_runwayFrom = null;
						} else if (_runwayFrom == null && this._hand != null) {
								_runwayTo.PlaceCard (_hand.TakeCard ());
								_hand = null;
								_runwayTo = null;
						}
				} else {
						Debug.Log ("Full Runway");
				}
		}

		private void CalculateRound ()
		{
				foreach (var runWay in runWayControllers) {
						if (runWay.Aircraft.TheAircraft != null) {
								runWay.Aircraft.TheAircraft.Cleanlyness -= runWay.Fields.getCleanSkill ();
								runWay.Aircraft.TheAircraft.Maintenance -= runWay.Fields.getMaintenanceSkill ();
								if (runWay.Aircraft.TheAircraft.Cleanlyness <= 0 && runWay.Aircraft.TheAircraft.Maintenance <= 0) {
										runWay.Aircraft.DriveIntoHangar ();
								}
						}
				}
				List<GameEvent> tmp = new List<GameEvent> ();
				foreach (var e in gameEvents) {
						e.TimeUntil--;
						if (e.TimeUntil == 0) {
								e.Spawn ();
								tmp.Add (e);
						}
				}
				foreach (var item in tmp) {
						gameEvents.Remove (item);
				}
		}

		private void GenerateEventsForNextRound ()
		{
				var e = RandomEventGenerator.Instance.GenerateElement ();
				if (e != null) {
						gameEvents.Add (e);
				}
		}
}
