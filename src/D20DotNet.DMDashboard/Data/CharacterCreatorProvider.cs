using D20DotNet.Base.Characters.Classes;
using D20DotNet.Base.Characters.Race;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D20DotNet.DMDashboard.Data
{
	public class CharacterCreatorProvider
	{
		public List<IRace> CharacterRaces
		{
			get
			{
				return new List<IRace>()
				{
					CommonRaces.Halfling
				};
			}
		}

		public List<IClass> CharacterClasses
		{
			get
			{
				return new List<IClass>()
				{
					CommonClasses.Rouge
				};
			}
		}
	}
}
