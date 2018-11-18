using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D20DotNet.Base.Characters;
using D20DotNet.Base.Characters.Creation;
using D20DotNet.Base.Characters.Race;
using D20DotNet.Base.Characters.Classes;
using D20DotNet.Base.Dice;

namespace D20DotNet.DMDashboard
{
    public class DashboardController
    {
		public List<CharacterBase> GetCharacters()
		{
			CharacterFactoryBase factoryBase =
				new NormalCharacterFactoryBase(
					new SimpleRoll(3, 6, 0),
					CommonRaces.Halfling,
					CommonClasses.Rouge);

			return Enumerable.Range(1, 10)
				.Select(i => factoryBase.CreateCharacter())
				.ToList();
		}
    }
}
