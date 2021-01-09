using Xamarin.Forms;
using Notes.Views;

namespace Notes
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			MainPage = new NavigationPage(new MainPage());
		}
	}
}
