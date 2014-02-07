using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace AssemblyCSharp
{
		public class SpawnController
		{
				private static SpawnController instance;
				private Dictionary<string,string> cards = new Dictionary<string,string> ();
				private Dictionary<string,Texture> cardTextures = new Dictionary<string,Texture> ();

				private SpawnController ()
				{
						cards.Add ("AircraftInspectorCard", "p_aircraftinspector");
						cards.Add ("CoffeeCard", "n_kaffee");
						cards.Add ("Draw2CardsCard", "e_zweikarten");
						cards.Add ("FacilityManagerTrainingCard", "s_facilitymanagerausbildung");
						cards.Add ("FurtherPersonellTrainingCard", "s_wifiausbildung");
						cards.Add ("GarageManageTrainingCard", "s_werkstaettenleiterausbildung");
						cards.Add ("IllnessCard", "e_krankheit");
						cards.Add ("MechanicCard", "p_mechaniker");
						cards.Add ("Place2EnhancementCard", "e_zweiaufwertungen");
						cards.Add ("Place2PersonCard", "e_zweiarbeiter");
						cards.Add ("PowerFlannelCard", "w_hoellenwaschlappen");
						cards.Add ("RedbullCard", "n_energiedrink");
						cards.Add ("Vacuum2000Card", "w_staubsauger");
						cards.Add ("WaterCard", "n_wasser");
						cards.Add ("WrenchUltraMega2002Card", "w_schrauber");
						cards.Add ("CrewLeaderCard", "p_crewleader");

						Debug.Log ("Loading Textures");
						foreach(KeyValuePair<string,string> item in cards)
						{
								cardTextures.Add (item.Key, Resources.Load (item.Value) as Texture);
						}

				}

				public static SpawnController GetInstance ()
				{
						if (instance == null) {
								instance = new SpawnController ();
						}
						return instance;
				}

				public Texture GetCardTexture(Card card)
				{
						return cardTextures [card.getName ()];
				}

				public void ChangeCardTexture (GameObject obj, Card card)
				{
						Debug.Log ("Texture for " + cards [card.getName ()]);
						obj.renderer.material.mainTexture = this.GetCardTexture(card);
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
						//http://docs.unity3d.com/Documentation/ScriptReference/GameObject.AddComponent.html
						GameObject spawn = AssetDatabase.LoadAssetAtPath ("Assets/Resources/" + "Cessna172.fbx", typeof(GameObject)) as GameObject;
						PrefabUtility.CreatePrefab ("Assets/Resource/" + "Cessna172" + ".prefab", spawn);
						spawn = GameObject.Instantiate (spawn, position, rotation) as GameObject;
						spawn.transform.localScale = new Vector3 (6, 6, 6);
						return spawn;
				}
		}
}