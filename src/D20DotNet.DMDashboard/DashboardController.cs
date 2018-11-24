using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D20DotNet.DMDashboard.VM;
using D20DotNet.Base.Characters;
using D20DotNet.Base.Characters.Creation;
using D20DotNet.Base.Characters.Race;
using D20DotNet.Base.Characters.Classes;
using D20DotNet.Base.Dice;
using D20DotNet.DMDashboard.Data;

namespace D20DotNet.DMDashboard
{
    public class DashboardController
    {
		private CharacterCreatorProvider _characterCreatorProvider;
		public List<CharacterBattleVM> GetCharacters()
		{
			CharacterFactoryBase factoryBase =
				new NormalCharacterFactoryBase(
					new SimpleRoll(3, 6, 0),
					CommonRaces.Halfling,
					CommonClasses.Rouge);

			return Enumerable.Range(1, 10)
				.Select(i => factoryBase.CreateCharacter())
				.Select(i => new VM.CharacterBattleVM(i))
				.ToList();
		}

		public List<CharacterBattleVM> EditRoster(List<CharacterBattleVM> roster)
		{
			if (_characterCreatorProvider == null)
				_characterCreatorProvider = new CharacterCreatorProvider();

			EditRosterVM data = new EditRosterVM();

			foreach (var characterClass in _characterCreatorProvider.CharacterClasses)
				data.Classes.Add(characterClass);

			foreach (var characterRace in _characterCreatorProvider.CharacterRaces)
				data.Races.Add(characterRace);

			foreach (var combatent in roster)
				data.Combatents.Add(combatent);

			Windows.EditRosterWindow editRosterWindow = new Windows.EditRosterWindow();
			editRosterWindow.EditRosterVM = data;

			editRosterWindow.ShowDialog();

			return data.Combatents.ToList();
		}
    }
}
