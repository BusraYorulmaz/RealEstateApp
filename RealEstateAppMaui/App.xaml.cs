using RealEstateAppMaui.Pages;

namespace RealEstateAppMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var accesToken = Preferences.Get("accesstoken", string.Empty);
            if (string.IsNullOrEmpty(accesToken))
            {
                MainPage = new NavigationPage(new RegisterPage());
            }
            else
            {
                MainPage = new CustomTabbedPage();
            }
        }
    }
}