using System;
using System.Collections.Generic;
using System.Text;

namespace D20DotNet.Base.Characters.Race
{
	public static class CommonRaces
	{
		public static BasicRace Halfling =
			new BasicRace("Halfling", 25)
			{
				AdjustmentDEX = 2,
				Skills = new HashSet<string>()
				{
					"Lucky",
					"Brave",
					"Nimble"
				},
				Languages = new HashSet<string>()
				{
					"Common",
					"Halfling"
				}
			};
	}
}
