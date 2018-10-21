using System;
using System.Collections.Generic;
using System.Text;

namespace DND5E.Base.Dice
{
	public abstract class DiceRoll
	{
		protected static Random random = new Random();
		public abstract int Roll();
	}
}
