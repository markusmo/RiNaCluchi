using UnityEngine;

//using UnityEditor;
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
						cards.Add ("AircraftInspectorCard", "aircraftinspector");
			cards.Add ("CoffeeCard", "coffee");
			cards.Add ("Draw2CardsCard", "picktwocards");
			cards.Add ("FacilityManagerTrainingCard", "facilitymanagertraining");
			cards.Add ("FurtherPersonellTrainingCard", "advancedtraining");
			cards.Add ("GarageManageTrainingCard", "extendedmechanictraining");
			cards.Add ("IllnessCard", "sickness");
			cards.Add ("MechanicCard", "mechanic");
			cards.Add ("Place2EnhancementCard", "laytwoupgrades");
			cards.Add ("Place2PersonCard", "twoworkers");
			cards.Add ("PowerFlannelCard", "washclothofdeath");
			cards.Add ("RedbullCard", "energydrink");
			cards.Add ("Vacuum2000Card", "vacuum");
			cards.Add ("WaterCard", "water");
			cards.Add ("WrenchUltraMega2002Card", "drill");
						cards.Add ("CrewLeaderCard", "crewleader");

						Debug.Log ("Loading Textures");
						foreach (KeyValuePair<string,string> item in cards) {
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

				public Texture GetCardTexture (Card card)
				{
						return cardTextures [card.getName ()];
				}

				public void ChangeCardTexture (GameObject obj, Card card)
				{
						if (card != null) {
								Debug.Log ("Texture for " + cards [card.getName ()]);
								obj.renderer.material.mainTexture = this.GetCardTexture (card);
						}
				}

				/// <summary>
				/// Spawns the aircraft. currenty only a Cesna172 hardcoded
				/// </summary>
				/// <returns>The aircraft.</returns>
				/// <param name="position">Position.</param>
				/// <param name="rotation">Rotation.</param>
				/// <param name="aircraft">Planename.</param>
				public GameObject SpawnAircraft (int runway, Vector3 position, Quaternion rotation, Aircraft aircraft)
				{
						//fbx has to be located in "Resources" folder in project view
						//http://docs.unity3d.com/Documentation/ScriptReference/GameObject.AddComponent.html
						GameObject spawn = Resources.Load ("Cessna172", typeof(GameObject)) as GameObject;
						spawn = GameObject.Instantiate (spawn, position, rotation) as GameObject;
						spawn.transform.localScale = new Vector3 (6, 6, 6);
						AirCraftController ac = (AirCraftController)spawn.AddComponent ("AirCraftController");
						ac.setAircraftFBX (spawn);
						ac.setSpawnpoint (runway);
						ac.setIsSpawned ();
						return spawn;
				}
		}
}