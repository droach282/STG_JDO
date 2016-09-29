using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace STG_RestaurantBuzzer
{
    public partial class MainPage : ContentPage
    {
        private readonly ObservableCollection<Party> _groups = new ObservableCollection<Party>();

        private readonly IPartyRepository _partyRepository = DependencyService.Get<IPartyRepository>();

        private Party _myParty;

        public MainPage()
        {
            InitializeComponent();
            GroupListView.ItemsSource = _groups;

            for (var i = 1; i <= 10; i++)
                PartySizePicker.Items.Add(i.ToString());

            RefreshParties();

            Device.StartTimer(new TimeSpan(0, 1, 0), RefreshParties);
        }

        private void AddToWaitListButton_OnClicked(object sender, EventArgs e)
        {
            _myParty = new Party
            {
                Name = GroupNameEntry.Text,
                PartySize = (short) (PartySizePicker.SelectedIndex + 1),
                WaitMinutes = 15
            };

            _partyRepository.CreateParty(_myParty);
            RefreshParties();

            AddToSeatingListFrame.IsVisible = false;
            ThanksFrame.IsVisible = true;
        }

        private bool RefreshParties()
        {
            var tableReady = false;

            _groups.Clear();
            foreach (var party in _partyRepository.WaitingParties())
            {
                _groups.Add(party);
                if (party.Id == _myParty?.Id && party.WaitMinutes == 0)
                {
                    DisplayAlert("Time to eat!", "Your table is ready! Please check in with the host to be seated.",
                        "OK!");
                    tableReady = true;
                }
            }

            return !tableReady;
        }

        private void UpdateButton_OnClicked(object sender, EventArgs e)
        {
           RefreshParties(); 
        }
    }
}
