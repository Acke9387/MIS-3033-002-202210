﻿using System;
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

namespace WPF_VowelsAndConsonants
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

        private void btnSplit_Click(object sender, RoutedEventArgs e)
        {
            string word = txtInput.Text;
            /* if they entered 'hello'
            word[0] = 'h';
            word[1] = 'e';
            word[2] = 'l';
            word[3] = 'l';
            word[4] = 'o';
            */

        }
    }
}
