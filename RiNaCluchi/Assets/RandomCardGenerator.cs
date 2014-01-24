using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
		public class RandomCardGenerator : RandomGenerator<Card>
		{
				private static RandomCardGenerator instance;
			
				private RandomCardGenerator ()
				{
						elements = new List<KeyValuePair<Type,double>> ();
						this.AddElement("AssemblyCSharp.CoffeeCard", new CoffeeCard ().getProbability ());
						this.AddElement ("AssemblyCSharp.AircrafInspectorCard", new AircrafInspectorCard ().getProbability ());
						this.AddElement ("AssemblyCSharp.CrewLeaderCard", new CrewLeaderCard ().getProbability ());
						this.AddElement ("AssemblyCSharp.Draw2CardsCard", new Draw2CardsCard ().getProbability ());
						this.AddElement ("AssemblyCSharp.FacilityManagerTrainingCard", new FacilityManagerTrainingCard ().getProbability ());
						this.AddElement ("AssemblyCSharp.FurtherPersonellTrainingCard", new FurtherPersonellTrainingCard ().getProbability ());
						this.AddElement ("AssemblyCSharp.GarageManageTrainingCard", new GarageManageTrainingCard ().getProbability ());
						this.AddElement ("AssemblyCSharp.IllnesCard", new IllnesCard ().getProbability ());
						this.AddElement ("AssemblyCSharp.MechanicCard", new MechanicCard ().getProbability ());	
						this.AddElement ("AssemblyCSharp.Place2EnchancementCard", new Place2EnchancementCard ().getProbability ());
						this.AddElement ("AssemblyCSharp.Place2PersonCard", new Place2PersonCard ().getProbability ());
						this.AddElement ("AssemblyCSharp.PowerFlannelCard", new PowerFlannelCard ().getProbability ());
						this.AddElement ("AssemblyCSharp.RedBullCard", new RedBullCard ().getProbability ());
						this.AddElement ("AssemblyCSharp.Vacuum2000Card", new Vacuum2000Card ().getProbability ());	
						this.AddElement ("AssemblyCSharp.WaterCard", new WaterCard ().getProbability ());
						this.AddElement ("AssemblyCSharp.WrenchUltraMega2002Card", new WrenchUltraMega2002Card ().getProbability ());
				}
			
				public static RandomCardGenerator Instance {
						get {
								if (instance == null) {
					instance = new RandomCardGenerator ();
								}
								return instance;
						}
				}

				private List<KeyValuePair<Type,double>> elements;

				

				public override void AddElement (string element, double probability)
				{
						this.elements.Add (new KeyValuePair<Type, double> (Type.GetType(element), probability));
				}

				public override Card GenerateElement ()
				{
						Random r = new Random ();
						double dice = r.NextDouble ();

						double cumulative = 0.0;
						for (int i = 0; i < elements.Count; i++) {
								cumulative += elements [i].Value;
								if (dice < cumulative) {
										return (Card)Activator.CreateInstance (elements [i].Key);
								}
						}
						return null;
				}
		}
}

