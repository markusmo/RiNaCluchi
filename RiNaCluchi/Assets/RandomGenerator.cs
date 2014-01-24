using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;

namespace AssemblyCSharp
{
	public abstract class RandomGenerator<T> where T : Type
	{
		private List<KeyValuePair<T,double>> elements;

		public RandomGenerator ()
		{
			this.elements = new List<KeyValuePair<T,double>> ();
		}

		public void AddElement (T element, double probability)
		{
			this.elements.Add (new KeyValuePair<T, double> (element, probability));
		}

		public T generateElement()
		{
			Random r = new Random ();
			double dice = r.NextDouble ();

			double cumulative = 0.0;
			for (int i = 0; i < elements.Count; i++) 
			{
				cumulative += elements [i].Value;
				if (dice < cumulative) 
				{
					return Activator.CreateInstance(elements[i].Key);
				}
			}
		}
	}
}

