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

				public GameObject SpawnCard(Vector3 position,Quaternion rotation, Card card)
				{
						GameObject original = GameObject.FindWithTag ("stackCard");	
						GameObject clone;
						clone = (GameObject) GameObject.Instantiate (original, position, rotation);

						return clone;
				}

				/// <summary>
				/// Spawns the aircraft. currenty only a Cesna172 hardcoded
				/// </summary>
				/// <returns>The aircraft.</returns>
				/// <param name="position">Position.</param>
				/// <param name="rotation">Rotation.</param>
				/// <param name="aircraft">Planename.</param>
				public GameObject SpawnAircraft (Vector3 position, Quaternion rotation, Aircraft aircraft)
				{
						//if not working try http://docs.unity3d.com/Documentation/ScriptReference/Resources.LoadAssetAtPath.html
						//fbx has to be located in "Resources" folder in project view 
						GameObject spawn = (GameObject) Resources.Load ("Cesna172.fbx");
						spawn = (GameObject) GameObject.Instantiate (spawn, position, rotation);
						return spawn;
				}
	}
}