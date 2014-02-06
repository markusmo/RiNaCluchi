using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

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
						cards.Add ("AircraftInspectorCard", "p_aircraftinspector.png");
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
						clone = (GameObject) GameObject.Instantiate (original, position, rotation);
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
						GameObject spawn = (GameObject) Resources.Load ("Cesna172.fbx");
						spawn = (GameObject) GameObject.Instantiate (spawn, position, rotation);
						return spawn;
				}
	}
}