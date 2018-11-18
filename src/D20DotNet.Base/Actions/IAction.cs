using System;
using System.Collections.Generic;
using System.Text;
using D20DotNet.Base.Dice;

namespace D20DotNet.Base.Actions
{
	public interface IAction
	{
		String Title { get; set; }
		String Description { get; set; }
		String ActionText { get; }

		DiceRoll ActionRoll { get; set; }
	}
}
