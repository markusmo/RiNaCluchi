using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class RunwayCardFieldsController : MonoBehaviour
{

		// Use this for initialization
		RunwayCardField[] _fields;

		void Start ()
		{
				_fields = gameObject.GetComponentsInChildren<RunwayCardField> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public int getMaintenanceSkill ()
		{
				int i = 0;
				foreach (var item in _fields) {
						if (item.TheCard is PersonCard) {
								i += (item.TheCard as PersonCard).MaintenanceSkill;
						}
				}
				return i;
		}

		public int getCleanSkill ()
		{
				int i = 0;
				foreach (var item in _fields) {
						if (item.TheCard is PersonCard) {
								i += (item.TheCard as PersonCard).CleanSkill;
						}
				}
				return i;
		}

}
