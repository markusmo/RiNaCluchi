using UnityEngine;
using System;

namespace AssemblyCSharp
{
	public class SpawnController
	{
				private static SpawnController instance;

				private SpawnController(){}

				public static SpawnController GetInstance()
				{
						if (instance == null) 
						{
								instance = new SpawnController ();
						}
						return instance;
				}

				public GameObject SpawnCard(Vector3 position,Quaternion rotation)
				{
						GameObject card = GameObject.FindWithTag ("stackCard");
						GameObject clone;
						clone = (GameObject) GameObject.Instantiate (card, position, rotation);
						return clone;
				}

				/// <summary>
				/// Spawns the aircraft. currenty only a Cesna172
				/// </summary>
				/// <returns>The aircraft.</returns>
				/// <param name="position">Position.</param>
				/// <param name="rotation">Rotation.</param>
				/// <param name="planename">Planename.</param>
				public GameObject SpawnAircraft (Vector3 position, Quaternion rotation, String planename)
				{
						//if not working try http://docs.unity3d.com/Documentation/ScriptReference/Resources.LoadAssetAtPath.html
						//fbx has to be located in "Resources" folder in project view 
						GameObject aircraft = (GameObject) Resources.Load ("Cesna172.fbx");
						aircraft = (GameObject) GameObject.Instantiate (aircraft, position, rotation);
						return aircraft;
				}
	}
}