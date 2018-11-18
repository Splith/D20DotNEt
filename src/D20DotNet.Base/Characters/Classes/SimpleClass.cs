using System;
using System.Collections.Generic;
using System.Text;
using D20DotNet.Base.Actions;
using D20DotNet.Base.Dice;

namespace D20DotNet.Base.Characters.Classes
{
	public class BasicClass : IClass
	{
		public BasicClass()
		{
			Actions = new List<IAction>();
		}

		public BasicClass(String className, DiceRoll hitPointDice)
			: this()
		{
			ClassName = className;
			HitPointDice = hitPointDice;
		}

		public string ClassName { get; set; }
		public DiceRoll HitPointDice { get; set; }
		public StatEnum[] StatPriority { get; set; }
		public List<IAction> Actions { get; set; }
	}
}
