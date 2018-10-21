using System;
using System.Collections.Generic;
using System.Text;

namespace D20DotNet.Base.Dice
{
	public abstract class DiceRoll
	{
		protected static Random random = new Random();
		public abstract int Roll();
	}
}
