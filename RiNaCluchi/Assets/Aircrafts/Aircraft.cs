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
namespace AssemblyCSharp
{
		public abstract class Aircraft
		{
				public int Size {
						get;
						set;
				}

				public int Cleanlyness {
						get;
						set;
				}

				public int Maintenance {
						get;
						set;
				}

				public int Fuel {
						get;
						set;
				}

				public int TaxiTime {
						get;
						set;
				}

				public double getProbability ()
				{
						return 1 / 9.0;
				}

				public String Name{ get; set; }
		}

}