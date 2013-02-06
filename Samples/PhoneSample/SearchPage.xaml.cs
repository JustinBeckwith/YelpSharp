using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using YelpSharp;
using YelpSharp.Data.Options;

namespace PhoneSample
{
    public partial class SearchPage : PhoneApplicationPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var yelp = new Yelp(Config.Options);
            var task = yelp.Search(txtSearch.Text, txtLocation.Text);
            task.ContinueWith((results) =>
            {
                App.ViewModel = new ViewModels.SearchResultViewModel(results.Result);
                NavigationService.Navigate(new Uri("/SearchResultsPage.xaml"));
            });

        }



    }
}