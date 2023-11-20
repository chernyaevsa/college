using Client.Views;
namespace Client.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public MainWindowViewModel() 
		{
			_StudentsUserControl = new StudentsUserControl();
			_StudentsUserControl.DataContext = new StudentsUserControlViewModel();
		}

		public StudentsUserControl _StudentsUserControl { get; set; }
	}
}