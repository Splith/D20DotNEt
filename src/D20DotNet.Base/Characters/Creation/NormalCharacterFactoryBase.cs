using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using D20DotNet.Base.Dice;
using D20DotNet.Base.Actions;
using D20DotNet.Base.Characters.Classes;
using D20DotNet.Base.Characters.Race;

namespace D20DotNet.Base.Characters.Creation
{
	public class NormalCharacterFactoryBase : CharacterFactoryBase
	{
		public NormalCharacterFactoryBase()
		{
		}

		public NormalCharacterFactoryBase(DiceRoll baseStatRoll, IRace characterRace, IClass characterClass)
		{
			BaseStatRoll = baseStatRoll;
			Race = characterRace;
			Class = characterClass;
		}

		public IRace Race { get; set; }
		public IClass Class { get; set; }
		public DiceRoll BaseStatRoll { get; set; }
		public String CharacterDescription { get; set; }

		// ToDo: Make CreateCharacter use a challenge
		public override CharacterBase CreateCharacter()
		{
			var result = new CharacterBase(
				Class.HitPointDice,
				0,
				Race.Speed,
				0); // ToDo: Challenge should be provided by Create Character

			this.SetStats(result);

			foreach (String skill in Race.Skills)
				result.Skills.Add(skill);
			foreach (String lang in Race.Languages)
				result.Languages.Add(lang);

			return result;
		}

		protected void SetStats(CharacterBase character)
		{
			if (Class.StatPriority == null)
			{
				// Random Stats
				int[] stats = Enumerable.Range(1, 6)
					.Select(i => BaseStatRoll.Roll())
					.ToArray();

				character.INT = stats[0] + Race.AdjustmentINT;
				character.DEX = stats[1] + Race.AdjustmentDEX;
				character.CON = stats[2] + Race.AdjustmentCON;
				character.STR = stats[3] + Race.AdjustmentSTR;
				character.WIS = stats[4] + Race.AdjustmentWIS;
				character.CHA = stats[5] + Race.AdjustmentCHA;
			}
			else
			{
				// Stats by priority
				int[] stats = Enumerable.Range(1, 6)
					.Select(i => BaseStatRoll.Roll())
					.OrderByDescending(i => i)
					.ToArray();

				for (int i = 0; i < 6; ++i)
				{
					var currentStat = Class.StatPriority[i];

					switch (currentStat)
					{
						case StatEnum.INT:
							character.INT = stats[i] + Race.AdjustmentINT;
							break;
						case StatEnum.DEX:
							character.DEX = stats[i] + Race.AdjustmentDEX;
							break;
						case StatEnum.CON:
							character.CON = stats[i] + Race.AdjustmentCON;
							break;
						case StatEnum.STR:
							character.STR = stats[i] + Race.AdjustmentSTR;
							break;
						case StatEnum.WIS:
							character.WIS = stats[i] + Race.AdjustmentWIS;
							break;
						case StatEnum.CHA:
							character.CHA = stats[i] + Race.AdjustmentCHA;
							break;
					}
				}
			}
		}
	}
}
