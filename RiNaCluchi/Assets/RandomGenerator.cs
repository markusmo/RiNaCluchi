using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;

namespace AssemblyCSharp
{
		public abstract class RandomGenerator<T> where T : Type
		{
				public abstract void AddElement (Type element, double probability);

				public abstract T GenerateElement ();
		}
}

