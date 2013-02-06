using Microsoft.Phone.Controls;
using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using YelpSharp.Data;

namespace YelpSharpWP8Sample
{
    public partial class ListPage : PhoneApplicationPage
    {
        public ListPage()
        {
            InitializeComponent();
            this.DataContext = App.ListViewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            App.ListViewModel.Search();
        }

        private void BusinessLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?id=" + Uri.EscapeDataString(((Business)e.AddedItems[0]).id), UriKind.Relative));
        }
    }
}