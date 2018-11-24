using D20DotNet.DMDashboard.VM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
	/// Interaction logic for EditRosterControl.xaml
	/// </summary>
	public partial class EditRosterControl : UserControl
	{
		public EditRosterControl()
		{
			InitializeComponent();
		}

		public static readonly DependencyProperty EditRosterVMProperty =
			DependencyProperty.Register(
				"EditRosterVM",
				typeof(EditRosterVM),
				typeof(EditRosterControl),
				new FrameworkPropertyMetadata
				{
					BindsTwoWayByDefault = true,
					DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
				});

		public EditRosterVM EditRosterVM
		{
			get => (EditRosterVM)GetValue(EditRosterVMProperty);
			set => SetValue(EditRosterVMProperty, value);
		}
	}
}
