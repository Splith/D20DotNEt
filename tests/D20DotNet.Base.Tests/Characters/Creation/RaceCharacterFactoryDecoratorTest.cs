using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using D20DotNet.Base.Characters;
using D20DotNet.Base.Characters.Creation;
using D20DotNet.Base.Characters.Race;
using D20DotNet.Base.Characters.Classes;
using D20DotNet.Base.Dice;

namespace D20DotNet.Base.Tests.Characters.Creation
{
	[TestClass]
	public class RaceCharacterFactoryDecoratorTest
	{

		[TestMethod]
		public void ModifyStats()
		{
			NormalCharacterFactoryBase characterFactory = new NormalCharacterFactoryBase(
				new ConstantRoll(10),
				new BasicRace("Test", 30)
				{
					AdjustmentCON = 2,
				},
				new SimpleClass("Test", new ConstantRoll(20)));

			foreach (var skill in new HashSet<String>() { "Darkvision", "Dwarvin Resilliance", "Stonecutting" })
				characterFactory.Race.Skills.Add(skill);

			CharacterBase character = characterFactory.CreateCharacter();
			character.Level = 1;

			Assert.IsTrue(character.HitPoints == 21);
			Assert.IsTrue(character.INT == 10);
			Assert.IsTrue(character.WIS == 10);
			Assert.IsTrue(character.CON == 12);
			Assert.IsTrue(character.Skills.Contains("Darkvision"));
		}
	}
}
