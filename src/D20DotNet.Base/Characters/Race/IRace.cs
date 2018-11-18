using System;
using System.Collections.Generic;
using System.Text;

namespace D20DotNet.Base.Characters.Race
{
	public interface IRace
	{
		String RaceName { get; set; }

		int Speed { get; set; }

		int AdjustmentINT { get; set; }
		int AdjustmentDEX { get; set; }
		int AdjustmentCON { get; set; }
		int AdjustmentSTR { get; set; }
		int AdjustmentWIS { get; set; }
		int AdjustmentCHA { get; set; }

		HashSet<String> Skills { get; }
		HashSet<String> Languages { get; }
	}
}
