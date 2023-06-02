using RealEstateAppMaui.Services;

namespace RealEstateAppMaui.Pages;

public partial class RegisterPage : ContentPage
{
    private readonly ApiService _registerService = new ApiService();
    public RegisterPage()
    {
        InitializeComponent();
    }

    async void BtnRrgister_Clicked(object sender, EventArgs e)
    {
        var response = await _registerService.RegisterUser(EntryFullName.Text, EntryEmail.Text, EntryPassword.Text, EntryPhone.Text);
        if (response)
        {
            await DisplayAlert("", "Your Account has been created", "Alright");
            await Navigation.PushAsync(new LoginPage());

        }
        else
        {
            await DisplayAlert("", "Your Account hasn't been created", "Alright");

        }
    }

    async void TapLogin_Tapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}