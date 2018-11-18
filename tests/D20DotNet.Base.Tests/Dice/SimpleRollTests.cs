using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using D20DotNet.Base.Dice;
using System.Linq;

namespace D20DotNet.Base.Tests
{
	[TestClass]
	public class SimpleRollTests
	{
		[TestMethod]
		public void NSidesException()
		{
			try
			{
				SimpleRoll exNSides = new SimpleRoll(4, 1, 0);
				Assert.Fail("NSides Argument Exception was not thrown");
			}
			catch (Exception) { }

		}

		[TestMethod]
		public void NDiceException()
		{
			try
			{
				SimpleRoll exNDice = new SimpleRoll(-1, 6, 0);
				Assert.Fail("NDice Argument Exception was not thrown");
			}
			catch(Exception) { }
		}

		[TestMethod]
		public void TestRolls()
		{
			int lowerBound = 3;
			int upperBound = 13;

			SimpleRoll roll = new SimpleRoll(2, 6, 1);
			if (Enumerable.Range(1, 1000)
				.Select(i => roll.Roll())
				.Any(i => i < lowerBound || i > upperBound))
			{
				Assert.Fail();
			}
		}

		[TestMethod]
		public void SimpleRollDescription()
		{
			SimpleRoll oneDRoll = new SimpleRoll(1, 4, 2);
			SimpleRoll twoDRoll = new SimpleRoll(2, 6, 2);
			SimpleRoll negativeConstant = new SimpleRoll(2, 4, -4);

			Assert.AreEqual("1d4+2", oneDRoll.Description);
			Assert.AreEqual("2d6+2", twoDRoll.Description);
			Assert.AreEqual("2d4-4", negativeConstant.Description);
		}
	}
}
