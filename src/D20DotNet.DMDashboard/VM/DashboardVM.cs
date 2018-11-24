using D20DotNet.Base.Characters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D20DotNet.DMDashboard.VM
{
    public class DashboardVM : ViewModelBase
    {
		private DashboardController _controller;
		private RelayCommand _editRosterCommand;
		private RelayCommand _rollInitiativeCommand;

		public DashboardVM()
		{
			_controller = new DashboardController();
			Combatents = new ObservableCollection<CharacterBattleVM>();
		}

		public ObservableCollection<CharacterBattleVM> Combatents { get; private set; }

		public RelayCommand EditRosterCommand
		{
			get
			{
				if (_editRosterCommand == null)
				{
					_editRosterCommand =
						new RelayCommand((o) =>
						{
							var listOfCombatents = Combatents.ToList();
							Combatents.Clear();

							foreach (var character in _controller.EditRoster(listOfCombatents))
								Combatents.Add(character);
						});
				}

				return _editRosterCommand;
			}
		}

		public RelayCommand RollInitiativeCommand
		{
			get
			{
				if (_rollInitiativeCommand == null)
				{
					_rollInitiativeCommand = new RelayCommand(
						(o) =>
						{
							foreach (var character in Combatents)
							{
								if (!character.Initiative.HasValue)
									character.Initiative = Base.Dice.SimpleRoll.RollDice(1, 20, 0);
							}

							var characters = Combatents.ToList().OrderByDescending((c) => c.Initiative.HasValue ? c.Initiative.Value : int.MaxValue);
							Combatents.Clear();

							foreach (var character in characters)
								Combatents.Add(character);
						},
						(o) => 
						{
							return Combatents.Any((c) => !c.Initiative.HasValue);
						});
				}

				return _rollInitiativeCommand;
			}
		}
    }
}
