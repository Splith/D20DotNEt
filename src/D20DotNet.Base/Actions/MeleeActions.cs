using System;
using System.Collections.Generic;
using System.Text;
using D20DotNet.Base.Dice;

namespace D20DotNet.Base.Actions
{
	public class MeleeActions : IAction
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public DiceRoll ActionRoll { get; set; }

		public String ActionText => ActionRoll.Description + " " + Description;
			
	}
}
