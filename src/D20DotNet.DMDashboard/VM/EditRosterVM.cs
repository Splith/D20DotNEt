using D20DotNet.Base.Characters.Classes;
using D20DotNet.Base.Characters.Race;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D20DotNet.Base.Characters.Creation;
using D20DotNet.Base.Dice;

namespace D20DotNet.DMDashboard.VM
{
	public class EditRosterVM : ViewModelBase
	{
		private int _nDice;
		private int _nSides;
		private int _constant;

		private IRace _characterRace;
		private IClass _characterClass;

		private RelayCommand _createCharacter;
		private RelayCommand _copyCharacter;
		private RelayCommand _deleteCharacter;

		public EditRosterVM()
		{
			Races = new ObservableCollection<IRace>();
			Classes = new ObservableCollection<IClass>();
			Combatents = new ObservableCollection<CharacterBattleVM>();

			_nDice = 3;
			_nSides = 6;
			_constant = 0;
		}

		public int nDice
		{
			get => _nDice;
			set => SetProperty(ref _nDice, value);
		}

		public int nSides
		{
			get => _nSides;
			set => SetProperty(ref _nSides, value);
		}

		public int Constant
		{
			get => _constant;
			set => SetProperty(ref _constant, value);
		}

		public IRace CharacterRace
		{
			get => _characterRace;
			set => SetProperty(ref _characterRace, value);
		}

		public IClass CharacterClass
		{
			get => _characterClass;
			set => SetProperty(ref _characterClass, value);
		}

		public RelayCommand CreateCharacter
		{
			get
			{
				if (_createCharacter == null)
					_createCharacter =
						new RelayCommand(
							(o) => 
							{
								NormalCharacterFactoryBase factoryBase =
									new NormalCharacterFactoryBase(
										new SimpleRoll(_nDice, _nSides, _constant),
										_characterRace,
										_characterClass);

								CharacterBattleVM newCharacter = new CharacterBattleVM(factoryBase.CreateCharacter());
								Combatents.Add(newCharacter);
							},
							(o) => _characterRace != null && _characterClass != null);

				return _createCharacter;
			}
		}

		public RelayCommand DeleteCharacter
		{
			get
			{
				if (_deleteCharacter == null)
					_deleteCharacter =
						new RelayCommand(
							(o) =>
							{
								CharacterBattleVM character = (CharacterBattleVM)o;
								Combatents.Remove(character);
							});

				return _deleteCharacter;
			}
		}

		public RelayCommand CopyCharacter
		{
			get
			{
				if (_copyCharacter == null)
					_copyCharacter =
						new RelayCommand(
							(o) =>
							{
								CharacterBattleVM character = (CharacterBattleVM)o;
								CharacterBattleVM newChar = new CharacterBattleVM(character.Component);

								Combatents.Add(newChar);
							});

				return _copyCharacter;
			}
		}

		public ObservableCollection<IRace> Races { get; set; }
		public ObservableCollection<IClass> Classes { get; set; }
		public ObservableCollection<CharacterBattleVM> Combatents { get; set; }
	}
}
