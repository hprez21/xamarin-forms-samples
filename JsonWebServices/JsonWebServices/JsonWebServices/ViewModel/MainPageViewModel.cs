using System;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using JsonWebServices.Annotations;
using JsonWebServices.Model;
using Newtonsoft.Json;

namespace JsonWebServices.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region Properties
        private string _stationName;
        private int _elevation;
        private string _temperature;
        private int _humidity;
        public string StationName
        {
            get
            {
                return _stationName;
            }

            set
            {
                _stationName = value;
                OnPropertyChanged();
            }
        }
        public int Elevation
        {
            get
            {
                return _elevation;
            }

            set
            {
                _elevation = value;
                OnPropertyChanged();
            }
        }

        public string Temperature
        {
            get
            {
                return _temperature;
            }

            set
            {
                _temperature = value;
                OnPropertyChanged();
            }
        }

        public int Humidity
        {
            get
            {
                return _humidity;
            }

            set
            {
                _humidity = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Methods
        public async Task GetWeatherAsync(string url)
        {
            //Creamos una instancia de HttpClient
            var client = new HttpClient();
            //Asignamos la URL
            client.BaseAddress = new Uri(url);
            //Llamada asíncrona al sitio
            var response = await client.GetAsync(client.BaseAddress);
            //Nos aseguramos de recibir una respuesta satisfactoria
            response.EnsureSuccessStatusCode();
            //Convertimos la respuesta a una variable string
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            //Se deserializa la cadena y se convierte en una instancia de WeatherResult
            var weather = JsonConvert.DeserializeObject<WeatherResult>(jsonResult);
            //Asignamos el nuevo valor de las propiedades
            SetValue(weather);
        }

        private void SetValue(WeatherResult weather)
        {
            var stationName = weather.WeatherObservation.StationName;
            var elevation = weather.WeatherObservation.Elevation;
            var temperature = weather.WeatherObservation.Temperature;
            var humidity = weather.WeatherObservation.Humidity;

            StationName = stationName;
            Elevation = elevation;
            Temperature = temperature;
            Humidity = humidity;
        }
        #endregion

        #region InotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
