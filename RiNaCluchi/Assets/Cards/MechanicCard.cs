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
		public class MechanicCard : PersonCard
		{
				public MechanicCard ()
				{
						this.CleanSkill = 1;
						this.MaintenanceSkill = 3;

				}

				public override double getProbability ()
				{
						return 0.30;
				}

				public override Card Clone ()
				{
						MechanicCard rtVal = new MechanicCard ();
						rtVal.MaintenanceSkill = this.MaintenanceSkill;
						rtVal.CleanSkill = this.CleanSkill;
						rtVal.Tiredness = this.Tiredness;
						return rtVal;
				}

				public override string getName ()
				{
						return "MechanicCard";
				}
		}
}

