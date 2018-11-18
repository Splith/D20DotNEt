using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using D20DotNet.Base.Characters;
using D20DotNet.Base.Dice;

namespace D20DotNet.Base.Tests.Characters
{
	[TestClass]
	public class CharacterBaseTests
	{
		[TestMethod]
		public void LevelUpTest()
		{
			CharacterBase character = new CharacterBase(
				new ConstantRoll(10),
				0,
				30,
				0,
				10,
				10,
				15,
				10,
				10,
				10);

			Assert.IsTrue(character.HitPoints == 0, "Level 0");

			character.Level = 2;
			Assert.IsTrue(character.HitPoints == 24, "Level 2");

			character.Level = 4;
			Assert.IsTrue(character.HitPoints == 48, "Level 4");
		}
	}
}
