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
		public abstract class EnchancementCard : Card
		{
		
		public int MaintenancePlus{
			get;
			protected set;
		}
		
		public int CleanPlus {
			get;
			protected set;
		}
		
		public int Duration {
			get;
			protected set;
		}
		public int TirednessMinus {
			get;
			protected set;
		}
		public abstract double getProbability ();
		
		public abstract Card Clone ();
		}
}
