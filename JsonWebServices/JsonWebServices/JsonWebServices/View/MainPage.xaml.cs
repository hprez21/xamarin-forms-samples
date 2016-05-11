using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonWebServices.ViewModel;
using Xamarin.Forms;

namespace JsonWebServices.View
{    
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel vm;
        public MainPage()
        {
            vm = new MainPageViewModel();
            BindingContext = vm;
            InitializeComponent();
        }
        public async void OnClicked(object sender, EventArgs e)
        {
            var longitude = double.Parse(txtLongitude.Text);
            var latitude = double.Parse(txtLatitude.Text);
            
            var url = string.Format(@"http://api.geonames.org/findNearByWeatherJSON?formatted=true&lat={0}&lng={1}&username=demo&style=full", latitude, longitude);
            await vm.GetWeatherAsync(url);
        }
    }
}
