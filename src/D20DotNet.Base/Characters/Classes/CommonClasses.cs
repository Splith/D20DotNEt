using System;
using System.Collections.Generic;
using System.Text;
using D20DotNet.Base.Dice;
using D20DotNet.Base.Actions;

namespace D20DotNet.Base.Characters.Classes
{
	public static class CommonClasses
	{
		public static BasicClass Rouge =
			new BasicClass("Rouge", new SimpleRoll(1, 8, 0))
			{
				Actions = new List<Actions.IAction>()
				{
					new RangedAction("Crossbow", "", new SimpleRoll(1, 8, 0), 80, 320)
				}
			};
	}
}
