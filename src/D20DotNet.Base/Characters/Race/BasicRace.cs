using System;
using System.Collections.Generic;
using System.Text;

namespace D20DotNet.Base.Characters.Race
{
	public class BasicRace : IRace
	{
		public BasicRace()
		{
			Skills = new HashSet<string>();
			Languages = new HashSet<string>();
		}

		public BasicRace(String raceName, int speed)
			: this()
		{
			RaceName = raceName;
			Speed = speed;
		}

		public string RaceName { get; set; }

		public int Speed { get; set; }

		public int AdjustmentINT { get; set; }
		public int AdjustmentDEX { get; set; }
		public int AdjustmentCON { get; set; }
		public int AdjustmentSTR { get; set; }
		public int AdjustmentWIS { get; set; }
		public int AdjustmentCHA { get; set; }

		public HashSet<string> Skills { get; private set; }
		public HashSet<string> Languages { get; private set; }
	}
}
