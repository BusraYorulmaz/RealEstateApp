using RealEstateAppMaui.Models;
using RealEstateAppMaui.Services;
using RealEstateAppMaui.ViewModel;
using System.ComponentModel;
using System.Windows.Input;

namespace RealEstateAppMaui.Pages;

public partial class BookMarksPage : ContentPage
{
    private BookMarksViewModel _viewModel;

    public BookMarksPage()
    {
        InitializeComponent();
        _viewModel = new BookMarksViewModel();
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadProperties();
    }
    private void CvProperties_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as BookmarkList;
        if (currentSelection == null) return;
        Navigation.PushModalAsync(new PropertyDetailPage(currentSelection.PropertyId));
        ((CollectionView)sender).SelectedItem = null;
    }


}