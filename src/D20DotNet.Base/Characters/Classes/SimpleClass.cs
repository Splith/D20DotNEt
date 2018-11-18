using System;
using System.Collections.Generic;
using System.Text;
using D20DotNet.Base.Actions;
using D20DotNet.Base.Dice;

namespace D20DotNet.Base.Characters.Classes
{
	public class SimpleClass : IClass
	{
		public SimpleClass()
		{
			Actions = new List<IAction>();
		}

		public SimpleClass(String className, DiceRoll hitPointDice)
			: this()
		{
			ClassName = className;
			HitPointDice = hitPointDice;
		}

		public string ClassName { get; set; }
		public DiceRoll HitPointDice { get; set; }
		public StatEnum[] StatPriority { get; private set; }
		public List<IAction> Actions { get; private set; }
	}
}
