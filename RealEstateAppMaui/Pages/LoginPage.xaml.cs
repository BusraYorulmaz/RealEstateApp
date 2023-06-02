using RealEstateAppMaui.Services;

namespace RealEstateAppMaui.Pages;

public partial class LoginPage : ContentPage
{
    private readonly ApiService _loginService = new ApiService();
    public LoginPage()
    {
        InitializeComponent();
    }

    async void BtnLogin_Clicked(object sender, EventArgs e)
    {
        var response = await _loginService.Login(EntryEmail.Text, EntryPassword.Text);
        if (response)
        {
            Application.Current.MainPage = new CustomTabbedPage();
        }
        else
        {
            await DisplayAlert("Worning", "Ooops something went wrong.", "Ok");
        }
    }

    private  void TapJoinNow_Tapped(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new RegisterPage());
         Application.Current.MainPage = new RegisterPage();
    }
}