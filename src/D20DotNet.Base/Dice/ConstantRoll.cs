using System;
using System.Collections.Generic;
using System.Text;

namespace D20DotNet.Base.Dice
{
	public class ConstantRoll : DiceRoll
	{
		public ConstantRoll(int constant)
		{
			Constant = constant;
		}

		public int Constant { get; private set; }

		public override int Roll()
		{
			return Constant;
		}

		public override string Description
		{
			get => (Constant < 0 ? "- " : "+ ") + Math.Abs(Constant).ToString();
		}
	}
}
