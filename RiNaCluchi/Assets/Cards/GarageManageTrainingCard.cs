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
		public class GarageManageTrainingCard:EnchancementCard,TrainingCard
		{
				public GarageManageTrainingCard ()
				{
						this.MaintenancePlus = 1;
				}

				public override double getProbability ()
				{
						return 10.0 / 3/100;
				}
		public override Card Clone ()
		{
			GarageManageTrainingCard rtVal = new GarageManageTrainingCard();
			rtVal.CleanPlus = this.CleanPlus;
			rtVal.Duration = this.Duration;
			rtVal.MaintenancePlus = this.MaintenancePlus;
			rtVal.TirednessMinus = this.TirednessMinus;
			return rtVal;
		}
		}
}

