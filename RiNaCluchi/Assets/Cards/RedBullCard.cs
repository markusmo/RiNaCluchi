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
		public class RedBullCard:EnchancementCard, FoodCard
		{
				public RedBullCard ()
				{
						this.TirednessMinus = 2;
				}

				public override double getProbability ()
				{
						return (5 / 3.0) / 100;
				}

				public override Card Clone ()
				{
						RedBullCard rtVal = new RedBullCard ();
						rtVal.CleanPlus = this.CleanPlus;
						rtVal.Duration = this.Duration;
						rtVal.MaintenancePlus = this.MaintenancePlus;
						rtVal.TirednessMinus = this.TirednessMinus;
						return rtVal;
				}

				public override string getName ()
				{
						return "RedbullCard";
				}
		}
}

