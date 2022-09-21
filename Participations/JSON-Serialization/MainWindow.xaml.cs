using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace JSON_Serialization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Game> AllGames = new List<Game>();
        public MainWindow()
        {
            InitializeComponent();

            var allContentExceptHeader = File.ReadAllLines("all_games.csv").Skip(1);

            foreach (var line in allContentExceptHeader)
            {
                //         0      1           2        3         4          5
                //line = "name,platform,release_date,summary,meta_score,user_review"
                var pieces = line.Split(',');

                double review;
                string platform = pieces[1];

                if (cboPlatforms.Items.Contains(platform) == false)
                {
                    cboPlatforms.Items.Add(platform);
                }

                if (double.TryParse(pieces[5], out review) == false)
                {
                    Game g = new Game()
                    {
                        Name = pieces[0],
                        Platform = pieces[1],
                        ReleaseDate = pieces[2],
                        Summary = pieces[3],
                        MetaScore = Convert.ToInt32(pieces[4]),
                        UserReview = null
                    };
                    AllGames.Add(g);
                }
                else
                {
                    Game g = new Game()
                    {
                        Name = pieces[0],
                        Platform = pieces[1],
                        ReleaseDate = pieces[2],
                        Summary = pieces[3],
                        MetaScore = Convert.ToInt32(pieces[4]),
                        UserReview = Convert.ToDouble(pieces[5])
                    };
                    AllGames.Add(g);
                }


            }


            PopulateListBox(AllGames);
        }

        private void PopulateListBox(List<Game> allGames)
        {
            foreach (var game in allGames)
            {
                lstGames.Items.Add(game);
            }
        }

        private void cboPlatforms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedPlatform = (string)cboPlatforms.SelectedItem;
            lstGames.Items.Clear();

            foreach (var game in AllGames)
            {
                if (game.Platform == selectedPlatform)
                {
                    lstGames.Items.Add(game);
                }
            }

            //List<Game> matchedGames = AllGames.Where(x => x.Platform == selectedPlatform).ToList();
            //PopulateListBox(matchedGames);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string serializedData = JsonConvert.SerializeObject(lstGames.Items, Formatting.Indented);

            File.WriteAllText($"{cboPlatforms.SelectedItem.ToString()}_games.json", serializedData);

            MessageBox.Show("Successfully saved data.");
        }

        private void lstGames_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Game selected = (Game)lstGames.SelectedItem;

            GameDetails gd = new GameDetails();
            gd.PopulateData(selected);

            gd.ShowDialog();


        }
    }
}
