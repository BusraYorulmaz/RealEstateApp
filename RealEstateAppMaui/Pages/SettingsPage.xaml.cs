namespace RealEstateAppMaui.Pages;

public partial class SettingsPage : ContentPage
{
    private string phoneNumber = "0541 925 41 82";
    public SettingsPage()
    {
        InitializeComponent();
    }

    private void ButtonLogOut_Clicked(object sender, EventArgs e)
    {
        Preferences.Clear();
        Application.Current.MainPage = new LoginPage();
    }
    private void tapAbout_Tapped(object sender, EventArgs e)
    {
        //BottomPopup.IsVisible = true;

        if (BottomPopup.IsVisible)
        {
            BottomPopup.IsVisible = false;
        }
        else
        {
            BottomPopup.IsVisible = true;
        }
    }

    private void okButton_Clicked(object sender, EventArgs e)
    {
        BottomPopup.IsVisible = false;

    }

    private void tapAbout1_Tapped(object sender, EventArgs e)
    {
       // BottomPopup1.IsVisible = true;
        if (BottomPopup1.IsVisible)
        {
            BottomPopup1.IsVisible = false;
        }
        else
        {
            BottomPopup1.IsVisible = true;
        }
    }

    private void TapMessage_Tapped(object sender, EventArgs e)
    {
        var message = new SmsMessage("Hi! Can you help me please?", phoneNumber);
        Sms.ComposeAsync(message);
    }

    private void TapCall1_Tapped(object sender, EventArgs e)
    {
        PhoneDialer.Open(phoneNumber);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        BottomPopup1.IsVisible = false;
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        BottomPopup.IsVisible = true;
    }
}