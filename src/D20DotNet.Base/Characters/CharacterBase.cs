using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using D20DotNet.Base.Dice;
using D20DotNet.Base.Actions;

namespace D20DotNet.Base.Characters
{
	public class CharacterBase
	{
		public CharacterBase(
			DiceRoll hitPointDice,
			int level,
			int speed,
			Single challenge,
			int INT = 0,
			int DEX = 0,
			int CON = 0,
			int STR = 0,
			int WIS = 0,
			int CHA = 0)
			: this()
		{
			this.HitPointDice = hitPointDice;
			this._level = level;
			this._hitDiceRoll = Enumerable.Range(1, _level).Select(i => HitPointDice.Roll()).Sum();
			this.Speed = speed;
			this.Challenge = challenge;
			this.INT = INT;
			this.DEX = DEX;
			this.CON = CON;
			this.STR = STR;
			this.WIS = WIS;
			this.CHA = CHA;
		}

		private CharacterBase()
		{
			Skills = new HashSet<String>();
			Languages = new HashSet<String>();
			Actions = new List<IAction>();
		}

		private int _hitDiceRoll;
		private int _level;

		public virtual int HitPoints
		{
			get => _hitDiceRoll + ((CON - 10) / 2) * _level;
		}

		public virtual int ArmorClass
		{
			get => 10 + ((DEX - 10) / 2) * 2;
		}

		public virtual int Level
		{
			get => _level;
			set
			{
				// Increase HP if possible
				if (_level > value)
					throw new ArgumentException("Level cannot be lower than current level");
				else if (_level < value)
					_hitDiceRoll += Enumerable.Range(1, value - _level).Select(i => HitPointDice.Roll()).Sum();

				_level = value;
			}
		}

		public virtual String Description { get; set; }
		public virtual DiceRoll HitPointDice { get; set; }
		public virtual int Speed { get; set; }

		public virtual int INT { get; set; }
		public virtual int DEX { get; set; }
		public virtual int CON { get; set; }
		public virtual int STR { get; set; }
		public virtual int WIS { get; set; }
		public virtual int CHA { get; set; }

		public virtual HashSet<String> Skills { get; protected set; }
		public virtual HashSet<String> Languages { get; protected set; }
		public virtual List<IAction> Actions { get; protected set; }
		public virtual Single Challenge { get; protected set; }
	}
}
