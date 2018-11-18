using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using D20DotNet.Base.Dice;
using D20DotNet.Base.Characters;
using D20DotNet.Base.Characters.Creation;
using D20DotNet.Base.Characters.Classes;
using D20DotNet.Base.Characters.Race;
using D20DotNet.Base.Actions;

namespace D20DotNet.Base.Tests.Characters.Creation
{
	[TestClass]
	public class ClassCharacterFactoryDecoratorTest
	{
		private class DecreasingRoll : DiceRoll
		{
			private int _starting;
			public DecreasingRoll(int starting)
			{
				_starting = starting;
			}

			public override string Description => throw new NotImplementedException();

			public override int Roll()
			{
				return --_starting;
			}
		}

		private class TestCharacterClass : IClass
		{
			public string ClassName { get => "Normal"; set => throw new NotImplementedException(); }
			public DiceRoll HitPointDice { get => new SimpleRoll(1, 10, 0); set => throw new NotImplementedException(); }

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

		private class TestCharacterRace : IRace
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

		[TestMethod]
		public void StatQueueTest()
		{
			NormalCharacterFactoryBase factoryBase =
				new NormalCharacterFactoryBase(
					new DecreasingRoll(10),
					new TestCharacterRace(),
					new TestCharacterClass()
					);

			CharacterBase character = factoryBase.CreateCharacter();

			Assert.IsTrue(character.STR > character.CON, "Str > Con");
			Assert.IsTrue(character.CON > character.WIS, "Con > Wis");
			Assert.IsTrue(character.WIS > character.DEX, "Wis > Dex");
			Assert.IsTrue(character.DEX > character.CHA, "Dex > Cha");
			Assert.IsTrue(character.CHA > character.INT, "Cha > Int");
		}
	}
}
