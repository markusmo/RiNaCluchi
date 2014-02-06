using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
		public class RandomAircraftGenerator : RandomGenerator<Aircraft>
		{
				private List<KeyValuePair<Type,double>> elements;
				private static RandomAircraftGenerator instance;

				public static RandomAircraftGenerator Instance {
						get {
								if (instance == null) {
										instance = new RandomAircraftGenerator ();
								}
								return instance;
						}
				}

				private RandomAircraftGenerator ()
				{
						this.elements = new List<KeyValuePair<Type,double>> ();
						this.AddElement ("AssemblyCSharp.AW139", new AW139 ().getProbability ());
						this.AddElement ("AssemblyCSharp.CN235", new CN235 ().getProbability ());
						this.AddElement ("AssemblyCSharp.EC135", new EC135 ().getProbability ());
						this.AddElement ("AssemblyCSharp.FR172", new FR172 ().getProbability ());
						this.AddElement ("AssemblyCSharp.GIV", new GIV ().getProbability ());
						this.AddElement ("AssemblyCSharp.LR45", new LR45 ().getProbability ());
						this.AddElement ("AssemblyCSharp.PC9M", new PC9M ().getProbability ());
						this.AddElement ("AssemblyCSharp.SKA200", new SKA200 ().getProbability ());
				}

				public override void AddElement (string element, double probability)
				{
						this.elements.Add (new KeyValuePair<Type, double> (Type.GetType (element), probability));
				}

				public override Aircraft GenerateElement ()
				{
						Random r = new Random ();
						double dice = r.NextDouble ();

						double cumulative = 0.0;
						for (int i = 0; i < elements.Count; i++) {
								cumulative += elements [i].Value;
								if (dice < cumulative) {
										return (Aircraft)Activator.CreateInstance (elements [i].Key.GetType ());
								}
						}
						return null;
				}
		}
}

