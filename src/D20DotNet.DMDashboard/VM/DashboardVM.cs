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
							Combatents.Clear();

							foreach (var character in _controller.GetCharacters())
								Combatents.Add(character);
						});
				}

				return _editRosterCommand;
			}
		}
    }
}
