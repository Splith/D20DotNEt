using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D20DotNet.Base.Dice
{
	public class SimpleRoll : DiceRoll
	{
		private int _nDice;
		private int _nSides;
		private int _constant;

		public SimpleRoll(int nDice, int nSides, int constant)
		{
			if (nDice <= 0)
				throw new ArgumentException("Number of Dice cannot be less than 1", "nDice");

			if (nSides <= 1)
				throw new ArgumentException("Number of Sides cannot be less than 2", "nSides");

			_nDice = nDice;
			_nSides = nSides;
			_constant = constant;
		}

		public int NDice
		{
			get => _nDice;
		}

		public int NSides
		{
			get => _nSides;
		}

		public int Constant
		{
			get => _constant;
		}

		public override string Description
		{
			get
			{
				// Base description
				String result = String.Format("{0}d{1}", NDice, NSides);

				// Add / Subtract Constant 
				if (Constant != 0)
					result += (Constant < 0 ? "-" : "+") + Math.Abs(Constant);

				return result;
			}
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
