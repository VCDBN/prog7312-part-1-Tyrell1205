using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Dewey
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
           
        }


        private void ReplacingBooks_Click(object sender, RoutedEventArgs e)
        {

            Replacingbooks r = new Replacingbooks();
            r.Show();   

        }

        private void IdentifyingAreas_Click(object sender, RoutedEventArgs e)
        {

            IdentifyingAreas IA = new IdentifyingAreas();
            IA.Show();

        }

        private void Findcallnumbers_Click(object sender, RoutedEventArgs e)
        {
            Findcallnumbers f = new Findcallnumbers();
            f.Show();
        }

       

    }
}
