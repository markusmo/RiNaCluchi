using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;

namespace AssemblyCSharp
{
		public abstract class RandomGenerator<T> 
		{
				public abstract void AddElement (string element, double probability);

				public abstract T GenerateElement ();
		}
}

