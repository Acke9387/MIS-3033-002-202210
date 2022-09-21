using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace JSON_Serialization
{
    /// <summary>
    /// Interaction logic for GameDetails.xaml
    /// </summary>
    public partial class GameDetails : Window
    {

        public GameDetails()
        {
            InitializeComponent();
        }

        public void PopulateData(Game game)
        {
            lblTitle.Content = game.Name;
            txtMetaScore.Text = game.MetaScore.ToString();
            txtPlatform.Text = game.Platform;
            txtReleaseDate.Text = game.ReleaseDate;
            txtSummary.Text = game.Summary;
            txtUserReview.Text = game.UserReview.ToString();
        }

    }
}
