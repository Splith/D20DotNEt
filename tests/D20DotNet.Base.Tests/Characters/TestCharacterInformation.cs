using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D20DotNet.Base.Actions;
using D20DotNet.Base.Characters;
using D20DotNet.Base.Characters.Classes;
using D20DotNet.Base.Characters.Race;
using D20DotNet.Base.Dice;

namespace D20DotNet.Base.Tests.Characters
{
	public class TestCharacterClass : IClass
	{
		public TestCharacterClass()
		{
			HitPointDice = new SimpleRoll(1, 10, 0);
		}

		public TestCharacterClass(DiceRoll hitPointDice)
		{
			HitPointDice = hitPointDice;
		}

		public string ClassName { get => "Normal"; set => throw new NotImplementedException(); }
		public DiceRoll HitPointDice { get; set; }

		public StatEnum[] StatPriority => 
			new StatEnum[]
			{
				StatEnum.STR,
				StatEnum.CON,
				StatEnum.WIS,
				StatEnum.DEX,
				StatEnum.CHA,
				StatEnum.INT
			};

		public List<IAction> Actions => new List<IAction>();
	}

	public class TestCharacterRace : IRace
	{
		public string RaceName { get => "Human"; set => throw new NotImplementedException(); }
		public int Speed { get => 30; set => throw new NotImplementedException(); }
		public int AdjustmentINT { get => 0; set => throw new NotImplementedException(); }
		public int AdjustmentDEX { get => 0; set => throw new NotImplementedException(); }
		public int AdjustmentCON { get => 0; set => throw new NotImplementedException(); }
		public int AdjustmentSTR { get => 0; set => throw new NotImplementedException(); }
		public int AdjustmentWIS { get => 0; set => throw new NotImplementedException(); }
		public int AdjustmentCHA { get => 0; set => throw new NotImplementedException(); }

		public HashSet<string> Skills => new HashSet<string>();
		public HashSet<string> Languages => new HashSet<string>();
	}
}
