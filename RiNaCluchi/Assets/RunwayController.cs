using UnityEngine;
using System.Collections;

public class RunwayController : MonoBehaviour
{
		// Use this for initialization
		void Start ()
		{
				this.Aircraft = gameObject.GetComponentInChildren<AirCraftController> ();
				this.Fields = gameObject.GetComponentInChildren<RunwayCardFieldsController> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public RunwayCardFieldsController Fields {
				get;
				private			set;
		}

		public AirCraftController Aircraft {
				get;
				private			set;
		}
}
