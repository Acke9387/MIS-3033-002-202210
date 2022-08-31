using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
using static System.Net.Mime.MediaTypeNames;

namespace WPF_Classes
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

        private void lstToys_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Toy selectedToy = (Toy)lstToys.SelectedItem;
            if (selectedToy is null)
            {
                return;
            }
            imgToyPicture.Source = new BitmapImage(new Uri(selectedToy.Image));
            MessageBox.Show($"{selectedToy.GetAisle()}");
        }

        private void btnSaveToy_Click(object sender, RoutedEventArgs e)
        {
            string manufacturer = txtManufacturer.Text;
            Toy t = new Toy();
            t.Manufacturer = manufacturer;
            t.Name = txtName.Text;
            t.Image = txtImage.Text;
            double price;
            if (double.TryParse(txtPrice.Text, out price) == false)
            {
                MessageBox.Show("Please enter a valid price");
                return;
            }
            t.Price = price;

            lstToys.Items.Add(t);

            //txtPrice.Clear();
            txtPrice.Text = String.Empty;
            txtName.Clear();
            txtImage.Clear();
            txtManufacturer.Clear();
        }
    }
}
