using System;
using System.Collections.Generic;
using System.Text;
using D20DotNet.Base.Dice;
using D20DotNet.Base.Actions;

namespace D20DotNet.Base.Characters.Classes
{
	public interface IClass
	{
		String ClassName { get; set; }

		DiceRoll HitPointDice { get; set; }
		StatEnum[] StatPriority { get; }
		List<IAction> Actions { get; }
	}
}
