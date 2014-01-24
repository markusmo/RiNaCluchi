using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
		public class RandomAircraftGenerator : RandomGenerator<Aircraft>
		{
				private List<KeyValuePair<Type,double>> elements;

				public RandomAircraftGenerator ()
				{
						this.elements = new List<KeyValuePair<Type,double>> ();
				}

				public override void AddElement (Type element, double probability)
				{
						this.elements.Add (new KeyValuePair<Type, double> (element, probability));
				}

				public override Aircraft GenerateElement ()
				{
						Random r = new Random ();
						double dice = r.NextDouble ();

						double cumulative = 0.0;
						for (int i = 0; i < elements.Count; i++) {
								cumulative += elements [i].Value;
								if (dice < cumulative) {
										return (Aircraft) Activator.CreateInstance (elements [i].Key);
								}
						}
				}
		}
}

