using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;

using Uwp.Models.DTO;
using Uwp.Models;
using Uwp.ViewModels;

namespace Uwp.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {
        public ObservableCollection<HistoryEntry> Entries { get; private set; }

        public HistoryEntry SelectedEntry
        {
            get { return _selectedEntry; }
            set
            {
                _selectedEntry = value;
                if (_selectedEntry != null)
                {
                    MessengerInstance.Send(_selectedEntry);
                    _selectedEntry = null;
                    _navigationService.NavigateTo(nameof(HistoryEntryViewModel));
                }

                RaisePropertyChanged(() => SelectedEntry);
            }
        }

        public HistoryViewModel(INavigationService navigationService) : base(navigationService)
        {
            _history = new History();
            Title = "History";
            Entries = new ObservableCollection<HistoryEntry>();

            LoadEntries();
        }
        
        private async void LoadEntries()
        {
            await _history.LoadEntries();
            Entries.Clear();

            foreach (var entry in _history.Entries)
            {
                Entries.Add(entry);
            }
        }

        private HistoryEntry _selectedEntry;
        private History _history;
    }
}
