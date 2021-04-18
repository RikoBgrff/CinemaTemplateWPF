using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public dynamic Data { get; set; }
        HttpClient http = new HttpClient();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            HttpResponseMessage response = new HttpResponseMessage();
            var name = movieTextBox.Text;
            response = http.GetAsync($@"http://www.omdbapi.com/?apikey=e4d8a8d9&s={name}&plot=full").Result;
            var str = response.Content.ReadAsStringAsync().Result;
            Data = JsonConvert.DeserializeObject(str);
            movieImage.Source = Data.Search[0].Poster;
            movieLabel.Content = Data.Search[0].Title;
        }
            catch (Exception)
            {

                MessageBox.Show("not found qaqash direshme");
                    }
}
    }
}
