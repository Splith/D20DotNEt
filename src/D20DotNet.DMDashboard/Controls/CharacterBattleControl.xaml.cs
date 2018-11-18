using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using D20DotNet.DMDashboard.VM;
using D20DotNet.Base.Characters;

namespace D20DotNet.DMDashboard.Controls
{
	/// <summary>
	/// Interaction logic for CharacterBattleControl.xaml
	/// </summary>
	public partial class CharacterBattleControl : UserControl
	{
		public CharacterBattleControl()
		{
			InitializeComponent();
		}

		public static readonly DependencyProperty CharacterProperty =
			DependencyProperty.Register(
				"Character",
				typeof(CharacterBattleVM),
				typeof(CharacterBattleControl));

		public CharacterBase Character
		{
			get => (CharacterBase)GetValue(CharacterProperty);
			set => SetValue(CharacterProperty, value);
		}
	}
}
