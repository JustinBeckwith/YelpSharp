using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using YelpSharp;
using YelpSharp.Data;
using YelpSharp.Data.Options;

namespace YelpSharpWP8Sample.ViewModels
{
    public class ListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Business> Businesses { get; private set; }
        private SearchOptions _SearchOptions;

        public SearchOptions SearchOptions
        {
            get
            {
                return _SearchOptions;
            }
            set
            {
                if (value != _SearchOptions)
                {
                    _SearchOptions = value;
                    NotifyPropertyChanged("SearchOptions");
                }
            }
        }

        public ListViewModel()
        {
            this.Businesses = new ObservableCollection<Business>();

            this.SearchOptions = new SearchOptions()
            {
                //setting default search values for main page
                GeneralOptions = new GeneralOptions()
                {
                    term = "body",
                    category_filter = "tattoo",
                    radius_filter = 25 * 1609.34
                }
            };
        }

        public async void Search()
        {
            this.Businesses.Clear();

            Yelp yelp = new Yelp(Config.Options);

            SearchResults searchResults = await yelp.Search(this.SearchOptions);
            
            if(searchResults != null && searchResults.businesses != null)
            {
                for (int count = 0; count < searchResults.businesses.Count; count++)
                {
                    this.Businesses.Add(searchResults.businesses[count]);
                }
            }            
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
