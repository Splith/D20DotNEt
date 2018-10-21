using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DND5E.Base.Dice
{
	public class SimpleRoll : DiceRoll
	{
		private int _nDice;
		private int _nSides;
		private int _constant;

		public SimpleRoll(int nDice, int nSides, int constant)
		{
			_nDice = nDice;
			_nSides = nSides;
			_constant = constant;
		}

		public static int RollDice(int nDice, int nSides, int constant)
		{
			return Enumerable
				.Range(1, nDice)
				.Select(i => random.Next(1, nSides))
				.Sum() + constant;
		}

		public override int Roll()
		{
			return SimpleRoll.RollDice(_nDice, _nSides, _constant);
		}
	}
}
