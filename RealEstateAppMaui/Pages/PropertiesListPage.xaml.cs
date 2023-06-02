using RealEstateAppMaui.Models;
using RealEstateAppMaui.Services;
namespace RealEstateAppMaui.Pages;

public partial class PropertiesListPage : ContentPage
{
    private readonly ApiService _apiService = new ApiService();
    public PropertiesListPage(int categoryId, string categoryName)
    {
        InitializeComponent();
        Title = categoryName;
        GetPropertyList(categoryId);
    }

    private async void GetPropertyList(int categoryId)
    {
        var properties = await _apiService.GetPropertyByCategory(categoryId);
        CvProperties.ItemsSource = properties;
    }

    private void CvProperties_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as PropertyByCategory;
        if (currentSelection == null) return;
        Navigation.PushModalAsync(new PropertyDetailPage(currentSelection.Id));
        ((CollectionView)sender).SelectedItem = null;
    }
}