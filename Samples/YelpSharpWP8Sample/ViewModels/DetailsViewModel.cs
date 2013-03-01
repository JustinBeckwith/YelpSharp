using System;
using System.ComponentModel;
using YelpSharp;
using YelpSharp.Data;

namespace YelpSharpWP8Sample.ViewModels
{
    public class DetailsViewModel : INotifyPropertyChanged
    {
        public Business _Business { get; set; }

        public Business Business
        {
            get
            {
                return _Business;
            }
            set
            {
                if (value != _Business)
                {
                    _Business = value;
                    NotifyPropertyChanged("Business");
                }
            }
        }

        public DetailsViewModel()
        {

        }

        public async void GetBusiness(string businessId)
        {
            this.Business = null;

            Yelp yelp = new Yelp(Config.Options);

            this.Business = await yelp.GetBusiness(businessId);
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
