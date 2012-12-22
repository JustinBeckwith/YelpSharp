using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PhoneSample.Resources;
using YelpSharp.Data;

namespace PhoneSample.ViewModels
{
    public class SearchResultViewModel : INotifyPropertyChanged
    {
        public SearchResultViewModel(SearchResults results)
        {
            this.Items = new ObservableCollection<BusinessViewModel>();
            foreach (var b in results.businesses)
            {
                this.Items.Add(new BusinessViewModel() { ID = b.id, Name = b.name });
            }            
        }

        /// <summary>
        /// A collection for BusinessViewModel objects.
        /// </summary>
        public ObservableCollection<BusinessViewModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
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