using System;
using System.Collections.Generic;
using System.Text;
using D20DotNet.Base.Dice;

namespace D20DotNet.Base.Actions
{
	public abstract class RangedAction : IAction
	{
		public RangedAction()
		{
		}

		public RangedAction(String title, String description, DiceRoll actionRoll, int normalRange, int longRange = 0)
		{
			Title = title;
			Description = description;
			ActionRoll = actionRoll;
			NormalRange = normalRange;
			LongRange = longRange;
		}

		public string Title { get; set; }
		public string Description { get; set; }

		public DiceRoll ActionRoll { get; set; }

		public int NormalRange { get; set; }
		public int LongRange { get; set; }

		public String ActionText => String.Format(
			"{0} Range:{1} {2}",
			ActionRoll.Description,
			NormalRange + (NormalRange != LongRange ? "/" + LongRange : ""),
			Description);
	}
}
