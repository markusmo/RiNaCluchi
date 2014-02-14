using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class AirCraftController : MonoBehaviour
{
		// Use this for initialization
		void Start ()
		{
				iTween.MoveTo (airCraftFBX, iTween.Hash ("path", iTweenPath.GetPath (spawnpoint), "time", 5, "easetype", iTween.EaseType.easeInOutSine));
		}
	
		// Update is called once per frame
		void Update ()
		{
//				if (spawned) {
//						iTween.MoveTo (airCraftFBX, iTween.Hash ("path", iTweenPath.GetPath (spawnpoint), "time", 5, "easetype", iTween.EaseType.easeInOutSine));	
//				}
		}

		GameObject airCraftFBX;
		private string spawnpoint = "";

		public void setAircraftFBX (GameObject o)
		{
				airCraftFBX = o;
		}

		public Aircraft TheAircraft {
				get;
				set;
		}

		private bool spawned = false;

		public void setIsSpawned ()
		{
				spawned = true;
		}

		public void setSpawnpoint (int i)
		{
				switch (i) {
				case 1:
				case 2:
				case 3:
				case 4:
						spawnpoint = "takedown" + i;
						break;
				case 5:
				case 6:
				case 7:
				case 8:
						spawnpoint = "takeoff" + (i - 4);
						break;
				}
		}

		public void DriveIntoHangar ()
		{
		}
}
