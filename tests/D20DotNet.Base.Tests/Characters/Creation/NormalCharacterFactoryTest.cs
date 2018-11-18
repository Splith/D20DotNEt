using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using D20DotNet.Base.Characters;
using D20DotNet.Base.Characters.Creation;
using D20DotNet.Base.Dice;

namespace D20DotNet.Base.Tests.Characters.Creation
{
	[TestClass]
	public class CharacterFactoryBaseTest
	{
		[TestMethod]
		public void CharacterFactoryTest()
		{
			NormalCharacterFactoryBase characterFactory = new NormalCharacterFactoryBase(
				new ConstantRoll(10),
				new TestCharacterRace(),
				new TestCharacterClass(new ConstantRoll(12))
			);

			var character = characterFactory.CreateCharacter();
			character.Level = 1;

			Assert.IsTrue(character.Level == 1);
			Assert.IsTrue(character.ArmorClass == 10);
			Assert.IsTrue(character.CON == 10);
			Assert.IsTrue(character.Speed == 30);
			Assert.IsTrue(character.Challenge == 0);
			Assert.IsTrue(character.HitPoints == 12);
		}

		[TestMethod]
		public void CharacterLevelUp()
		{
			CharacterBase character = new CharacterBase(
				new ConstantRoll(10),
				1,
				0,
				10,
				10,
				10,
				10,
				10,
				10,
				0);

			Assert.IsTrue(character.HitPoints == 10);

			character.Level = 3;

			Assert.IsTrue(character.HitPoints == 30);
		}
	}
}
