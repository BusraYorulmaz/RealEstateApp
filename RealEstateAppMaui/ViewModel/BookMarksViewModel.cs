using RealEstateAppMaui.Models;
using RealEstateAppMaui.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAppMaui.ViewModel
{
    public class BookMarksViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;
        private ObservableCollection<BookmarkList> _properties;
        private bool _isRefreshing;
        private Command _refreshCommand;

        public ObservableCollection<BookmarkList> Properties
        {
            get { return _properties; }
            set
            {
                _properties = value;
                OnPropertyChanged(nameof(Properties));
            }
        }
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }
        public Command RefreshCommand => _refreshCommand ?? (_refreshCommand = new Command(async () => await ExecuteRefreshCommand()));
        public BookMarksViewModel()
        {
            _apiService = new ApiService();
            Properties = new ObservableCollection<BookmarkList>();

        }
        public async Task LoadProperties()
        {
            var properties = await _apiService.GetBookmarkList();
            Properties.Clear();
            foreach (var property in properties)
            {
                Properties.Add(property);
            }
        }
        private async Task ExecuteRefreshCommand()
        {
            IsRefreshing = true;
            await LoadProperties();
            IsRefreshing = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
