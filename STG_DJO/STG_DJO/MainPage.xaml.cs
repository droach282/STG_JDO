using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace STG_DJO
{
    public partial class MainPage : ContentPage
    {
        private readonly ObservableCollection<Group> _groups = new ObservableCollection<Group>();

        public MainPage()
        {
            InitializeComponent();
            GroupListView.ItemsSource = _groups;

            for (var i = 1; i <= 10; i++)
                PartySizePicker.Items.Add(i.ToString());
        }

        private void AddToWaitListButton_OnClicked(object sender, EventArgs e)
        {
            _groups.Add(new Group {Name = GroupNameEntry.Text, PartySize = (short)(PartySizePicker.SelectedIndex + 1), WaitMinutes = 15});
            AddToSeatingListFrame.IsVisible = false;
            ThanksFrame.IsVisible = true;
        }
    }
}
