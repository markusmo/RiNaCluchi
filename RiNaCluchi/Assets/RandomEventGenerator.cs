//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18331
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections;
using AssemblyCSharp;
using System.Collections.Generic;

namespace AssemblyCSharp
{
		public class RandomEventGenerator
		{
				public enum EventType
				{
						TakeOff,
						TakeDown,
						Nothing
				}
				private static RandomEventGenerator instance;
				
				private RandomEventGenerator ()
				{
			elements = new List<KeyValuePair<EventType,double>> ();
						this.AddElement (EventType.TakeOff, 0.4);
						this.AddElement (EventType.TakeDown, 0.4);
						this.AddElement (EventType.Nothing, 0.2);
									
				}
		
				public static RandomEventGenerator Instance {
						get {
								if (instance == null) {
										instance = new RandomEventGenerator ();
								}
								return instance;
						}
				}
		
		private List<KeyValuePair<EventType,double>> elements;
		
				public void AddElement (EventType element, double probability)
				{
						this.elements.Add (new KeyValuePair<EventType, double> (element, probability));
				}
		
				public GameEvent GenerateElement ()
				{
						Random r = new Random ();
						double dice = r.NextDouble ();
						
						int runway = r.Next (1, 4);
						double cumulative = 0.0;
						Aircraft ac = RandomAircraftGenerator.Instance.GenerateElement ();
						if (ac is RotoaryWing)
								runway = 4;
						for (int i = 0; i < elements.Count; i++) {
								cumulative += elements [i].Value;
								if (dice < cumulative) {
										switch (elements [i].Key) {
										case EventType.TakeOff:												
												return new TakeOffEvent (ac, ac.Size, runway);												
										case EventType.TakeDown:
												return new TakeDownEvent (ac, ac.Size, runway);												
										case EventType.Nothing:
												return null;											
										default:
												break;
										}
								}
						}
						return null;
				}
		}
}
