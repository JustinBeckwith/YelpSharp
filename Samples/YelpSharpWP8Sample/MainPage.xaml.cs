using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Navigation;
using Windows.Devices.Geolocation;
using YelpSharp.Data.Options;

namespace YelpSharpWP8Sample
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // To set the SearchOptions in the ListViewModel which will be further used while making search call on ListPage.xaml
            this.DataContext = App.ListViewModel;
            
            GetUserLocation();
        }

        private void Search_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (App.ListViewModel.SearchOptions.LocationOptions == null)
                MessageBox.Show("Identifying location. Please wait.");
            else if ((string.IsNullOrEmpty(App.ListViewModel.SearchOptions.GeneralOptions.term) &&
                string.IsNullOrEmpty(App.ListViewModel.SearchOptions.GeneralOptions.category_filter)) ||
                App.ListViewModel.SearchOptions.GeneralOptions.radius_filter <= 0)
                MessageBox.Show("Please enter a valid radius 1-25 along with a term or a valid yelp category.");
            else
                NavigationService.Navigate(new Uri("/ListPage.xaml", UriKind.Relative));
        }

        private async void GetUserLocation()
        {
            Geolocator geolocator;
            Geoposition geoposition;

            geolocator = new Geolocator();

            geoposition = await geolocator.GetGeopositionAsync();

            App.ListViewModel.SearchOptions.LocationOptions = new CoordinateOptions()
            {
                latitude = geoposition.Coordinate.Latitude,
                longitude = geoposition.Coordinate.Longitude
            };

        }
                       
    }

    public class RadiusConvertor : System.Windows.Data.IValueConverter
    {
        // This converts the radius value in miles
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            double radius;
            if (value != null && double.TryParse(value.ToString(), out radius))
            {
                double.TryParse(value.ToString(), out radius);
                if (radius > 0)
                    return radius / 1609.34;
            }
            return 0;
        }

        // This converts the miles value back to radius
        public object ConvertBack(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            double miles;
            double.TryParse(value.ToString(), out miles);
            double radius = miles * 1609.34;
            return radius;
        }
    }

}