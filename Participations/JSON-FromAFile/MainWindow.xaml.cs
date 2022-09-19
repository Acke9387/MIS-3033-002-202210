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

namespace JSON_FromAFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Car> allData;
        public MainWindow()
        {
            InitializeComponent();

            string fileContents = File.ReadAllText("Mock_Data_Car_Owners.json");

            allData = JsonConvert.DeserializeObject<List<Car>>(fileContents);
            cboColors.Items.Add("All Colors");
            cboColors.SelectedIndex = 0;

            List<string> colors = new List<string>();
            foreach (Car car in allData)
            {
                if ( !colors.Contains(car.Color))//!cboColors.Items.Contains(car.Color) )
                {
                    //cboColors.Items.Add(car.Color);
                    colors.Add(car.Color);
                }

                lstCars.Items.Add(car);
            }

            foreach (string color in colors.OrderBy( x => x))
            {
                cboColors.Items.Add(color);
            }

            lblResults.Content = $"{lstCars.Items.Count.ToString("N0")} results found.";
        }

        private void cboColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedColor = (string)cboColors.SelectedItem;
            lstCars.Items.Clear();
            foreach (Car c in allData)
            {
                if (c.Color == selectedColor)
                {
                    lstCars.Items.Add(c);
                }
            }

            // **** New window example code

            //if (lstCars.Items.Count != 0)
            //{
            //    Details deets = new Details();
            //    deets.details = (Car)lstCars.Items[0];
            //    deets.PopulateData();
            //    deets.ShowDialog(); 
            //}

            lblResults.Content = $"{lstCars.Items.Count.ToString("N0")} results found.";
        }
    }
}
