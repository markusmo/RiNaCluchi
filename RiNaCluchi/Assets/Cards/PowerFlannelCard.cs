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
		public class PowerFlannelCard:EnchancementCard,ToolCard
		{
				public PowerFlannelCard ()
				{
						this.CleanPlus = 2;
						this.Duration = 6;
				}

				public override double getProbability ()
				{
					return (10 / 3 / 100.0);
				}

		public override Card Clone ()
		{
			PowerFlannelCard rtVal = new PowerFlannelCard();
			rtVal.CleanPlus = this.CleanPlus;
			rtVal.Duration = this.Duration;
			rtVal.MaintenancePlus = this.MaintenancePlus;
			rtVal.TirednessMinus = this.TirednessMinus;
			return rtVal;
		}
		}
}
