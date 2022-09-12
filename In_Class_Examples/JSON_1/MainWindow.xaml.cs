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
using System.IO;
using Newtonsoft.Json;

namespace JSON_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //process data here
            string json = File.ReadAllText("MOCK_DATA.json");

            List<Person> peeps = new List<Person>();

            peeps = JsonConvert.DeserializeObject<List<Person>>(json);

            foreach (Person person in peeps)
            {
                lstData.Items.Add(person); 
            }

        }
    }
}
