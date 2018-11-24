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

namespace D20DotNet.DMDashboard.Controls
{
	/// <summary>
	/// Interaction logic for IntegerUpDownTouch.xaml
	/// </summary>
	public partial class IntegerUpDownTouch : UserControl
	{
		public IntegerUpDownTouch()
		{
			InitializeComponent();
		}

		public static DependencyProperty NumberProperty =
			DependencyProperty.Register(
				"Number",
				typeof(int),
				typeof(IntegerUpDownTouch),
				new FrameworkPropertyMetadata()
				{
					BindsTwoWayByDefault = true,
					DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
				});

		public int Number
		{
			get => (int)GetValue(NumberProperty);
			set => SetValue(NumberProperty, value);
		}

		private void Button_Click_Up(object sender, RoutedEventArgs e)
		{
			Number = (Number + 1);
		}

		private void Button_Click_Down(object sender, RoutedEventArgs e)
		{
			Number = (Number - 1);
		}
	}
}
