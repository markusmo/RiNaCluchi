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
		public class Place2EnchancementCard:EventCard
		{
				public Place2EnchancementCard ()
				{
				}

				public override ICardEvent getEvent ()
				{
						throw new NotImplementedException ();
				}

				public override double getProbability ()
				{
						return 1.0 / 100;
				}

				public override Card Clone ()
				{
						return new Draw2CardsCard ();
			
				}

				public override string getName ()
				{
						return "Place2EnhancementCard";
				}
		}
}

