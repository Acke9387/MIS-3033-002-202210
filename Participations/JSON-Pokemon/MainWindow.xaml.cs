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

namespace JSON_Pokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PokemonDetails details;

        private bool showBack = false;

        public MainWindow()
        {
            InitializeComponent();

            string url = "https://pokeapi.co/api/v2/pokemon/?offset=0&limit=1200";
            PokemonAPI api = null; ;
            using (var client = new HttpClient())
            {
                var result = client.GetAsync(url).Result;

                if (result.IsSuccessStatusCode)
                {
                   
                    api = JsonConvert.DeserializeObject<PokemonAPI>(result.Content.ReadAsStringAsync().Result);
                }

            }

            if (api != null)
            {
                foreach (APIResult item in api.results.OrderBy(x => x.name))
                {
                    lstPokemon.Items.Add(item);
                } 
            }

        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            APIResult selected = (APIResult)lstPokemon.SelectedItem;

            using (var client = new HttpClient())
            {

                string json = client.GetStringAsync(selected.url).Result;

                details = JsonConvert.DeserializeObject<PokemonDetails>(json);

                txtHeight.Text = details.height.ToString();
                txtWeight.Text = details.weight.ToString();
                txtName.Text = details.name;

                img.Source = new BitmapImage(new Uri(details.sprites.front_default));
                showBack = true;
            }

        }

        private void btnRotate_Click(object sender, RoutedEventArgs e)
        {
            if (details != null)
            {
                if (showBack == true)
                {
                    if (details.sprites.back_default != null)
                    {
                        img.Source = new BitmapImage(new Uri(details.sprites.back_default)); 
                    }
                    showBack = false;
                }
                else
                {
                    img.Source = new BitmapImage(new Uri(details.sprites.front_default));
                    showBack = true;
                }
            }
        }
    }
}
