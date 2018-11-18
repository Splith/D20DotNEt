using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D20DotNet.Base.Characters;

namespace D20DotNet.DMDashboard.VM
{
	public class CharacterBattleVM : ViewModelBase
	{
		private CharacterBase _component;
		private int _battleHP;

		public CharacterBattleVM() { this.PropertyChanged += CharacterViewVM_PropertyChanged; }

		// Internal Event Listener
		private void CharacterViewVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			// If the component changes, update everything!
			if (e.PropertyName == "Component")
			{
				BattleHP = _component.HitPoints;
				OnPropertyChanged("Description");
				OnPropertyChanged("HitPoints");
				OnPropertyChanged("ArmorClass");
				OnPropertyChanged("Speed");
				OnPropertyChanged("ActionText");
			}
		}

		public CharacterBattleVM(CharacterBase component)
		{
			_component = component;
		}

		public CharacterBase Component
		{
			get => _component;
			set => SetProperty(ref _component, value);
		}

		public String Description
		{
			get => _component.Description;
		}

		public int HitPoints
		{
			get => _component.HitPoints;
		}

		public int ArmorClass
		{
			get => _component.ArmorClass;
		}

		public int Speed
		{
			get => _component.Speed;
		}

		public String ActionText
		{
			get
			{
				StringBuilder sbActionText = new StringBuilder();
				foreach (var action in _component.Actions)
					sbActionText.AppendLine(action.Description);

				return sbActionText.ToString();
			}
		}

		public int BattleHP
		{
			set => SetProperty(ref _battleHP, value);
			get => _battleHP;
		}
	}
}
