using Microsoft.Phone.Controls;
using System.Windows.Navigation;

namespace YelpSharpWP8Sample
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        public DetailsPage()
        {
            InitializeComponent();
            this.DataContext = App.DetailsViewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string id = "";
            if (NavigationContext.QueryString.TryGetValue("id", out id))
            {
                App.DetailsViewModel.GetBusiness(id);
            }
        }

    }
}