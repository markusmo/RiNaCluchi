using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class AirCraftController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(spawned){
			airCraftFBX.transform.position = calculatePosition();
		}
	}
	GameObject airCraftFBX;

	public void setAircraftFBX(GameObject o)
	{
		airCraftFBX = o;
	}
	public Aircraft TheAircraft{
				get;
				set;
		}
	private bool spawned = false;
	public void setIsSpawned()
	{
		spawned = true;
	}
	int spawnpoint = 0;

	public void setSpawnpoint(int i)
	{
		spawnpoint = i;
	}
	public void DriveIntoHangar()
	{
	}
	int frame = 0;
	private Vector3 calculatePosition()
	{
		frame++;
		Vector3 pOld = airCraftFBX.transform.position;
		Vector3 pNew = pOld;
		if(!(pOld.y < 0.25))
		{
				if(spawnpoint == 1 || spawnpoint == 2 || spawnpoint == 3)
				{
					pNew = pOld + new Vector3(0f,-0.01f,-0.5f);
				}
				else if(spawnpoint == 4)
				{
					pNew = pOld + new Vector3(0f,-0.01f,0f);
				}
		}
		 if(spawnpoint == 5 || spawnpoint == 6 || spawnpoint == 7)
		{
			pNew = pOld + new Vector3(0f,0.01f,0.5f);
		}
		else if(spawnpoint == 8)
		{
			pNew = pOld + new Vector3(0f,0.01f,0f);
		}
		return pNew;
	}
}
