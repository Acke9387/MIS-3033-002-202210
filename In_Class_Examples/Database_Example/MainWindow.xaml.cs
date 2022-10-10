using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Database_Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DB_128040_practiceContext DB = new DB_128040_practiceContext();
        public MainWindow()
        {
            InitializeComponent();

            //foreach (var movie in DB.Movie.Take(100))
            //{
            //    lstMovies.Items.Add(movie);
            //}

            foreach (var director in DB.Director.Include(x => x.Movie))
            {
                cboDirector.Items.Add(director);
            }

            // CREATING A new database record
            Director d = new Director();
            //d.DirectorId = 5;
            d.DirectorName = "Matthrew";

            DB.Director.Add(d);
            DB.SaveChanges();

            //DELETING a database record
            DB.Director.Remove(d);
            DB.SaveChanges();

            //UPDATING a database record
            var dir = DB.Director.Find(1);

            dir.DirectorName = "Matthrew";

            DB.SaveChanges();

            //Director name = DB.Director.Find(1);

            //MessageBox.Show($"Director with ID 1 is {name.DirectorName}");
        }

        private void cboDirector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstMovies.Items.Clear();
            Director selected = (Director)cboDirector.SelectedItem;

            //var movies = DB.Movie.Where(x => x.DirectorId == selected.DirectorId);

            foreach (var movie in selected.Movie)
            {
                lstMovies.Items.Add(movie);
            }

        }
    }
}
