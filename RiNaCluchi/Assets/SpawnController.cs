using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class SpawnController
	{
				private static SpawnController instance;
				private Dictionary<string,string> cards = new Dictionary<string,string>();

				private SpawnController()
				{
						cards.Add ("AircraftInspectorCard", "p_aircraftinspector.png");
						cards.Add ("CoffeeCard", "n_kaffee.png");
						cards.Add ("Draw2CardsCard", "e_zweikarten.png");
						cards.Add ("FacilityManagerTrainingCard", "s_facilitymanagerausbildung.png");
						cards.Add ("FurtherPersonellTrainingCard", "s_wifiausbildung.png");
						cards.Add ("GarageManageTrainingCard", "s_werkstaettenleiterausbildung.png");
						cards.Add ("IllnessCard", "e_krankheit.png");
						cards.Add ("MechanicCard", "p_mechaniker.png");
						cards.Add ("Place2EnhancementCard", "e_zweiaufwertungen.png");
						cards.Add ("Place2PersonCard", "e_zweiarbeiter.png");
						cards.Add ("PowerFlannelCard", "w_hoellenwaschlappen.png");
						cards.Add ("RedbullCard", "n_energiedrink.png");
						cards.Add ("Vacuum2000Card", "w_staubsauger.png");
						cards.Add ("WaterCard", "n_wasser.png");
						cards.Add ("WrenchUltraMega2002Card", "w_schrauber.png");
				}

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
						clone = GameObject.Instantiate (original, position, rotation) as GameObject;
						clone.renderer.material.mainTexture = Resources.Load (cards [card.getName()]) as Texture;
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
						//fbx has to be located in "Resources" folder in project view
						//http://forum.unity3d.com/threads/136130-Load-FBX-into-prefab
						GameObject spawn = AssetDatabase.LoadAssetAtPath("Assets/Resources/" + "Cesna172.fbx",typeof(GameObject)) as GameObject;
						PrefabUtility.CreatePrefab ("Assets/Resource/" + "Cesna172" + ".prefab", spawn);
						spawn = GameObject.Instantiate (spawn, position, rotation) as GameObject;
						return spawn;
				}
	}
}