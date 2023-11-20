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

namespace Dewey
{
    /// <summary>
    /// Interaction logic for Replacingbooks.xaml
    /// </summary>
    public partial class Replacingbooks : Window
    {
        // List that stores the generated call numbers 
        private List<ReplacingBooks> booksList = new List<ReplacingBooks>();

        // List that stores the order the user enters books
        private List<ReplacingBooks> userSelectionList = new List<ReplacingBooks>();

        // Declared an integer that will store the number of points
        private int points = 100;

        // Random instance for generating random numbers
        private Random randomVal = new Random();
        public Replacingbooks()
        {
            InitializeComponent();
            AddList();
            SortAndDisplayList();
        }

        // Method that generates 10 random values to the list and shuffles it
        private void AddList()
        {
            for (int i = 0; i < 10; i++)
            {
                double number = randomVal.NextDouble() * (899) + 100;

                // Code Attribution
                // https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
                const string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string surname = new string(Enumerable.Repeat(alpha, 3)
                    .Select(s => s[randomVal.Next(s.Length)]).ToArray());

                booksList.Add(new ReplacingBooks(number, surname));
            }

            // Shuffle the booksList
            booksList = booksList.OrderBy(x => randomVal.Next()).ToList();
        }


        // Method to sort the booksList using QuickSort
        private void QuickSort(List<ReplacingBooks> list, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(list, left, right);

                // Recursively sort elements before and after the pivot
                QuickSort(list, left, pivotIndex - 1);
                QuickSort(list, pivotIndex + 1, right);
            }
        }

        // Helper method for QuickSort to partition the list
        private int Partition(List<ReplacingBooks> list, int left, int right)
        {
            double pivot = list[right].code;
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (list[j].code <= pivot)
                {
                    i++;
                    Swap(list, i, j);
                }
            }

            Swap(list, i + 1, right);
            return i + 1;
        }

        // Helper method to swap two elements in the list
        private void Swap(List<ReplacingBooks> list, int i, int j)
        {
            ReplacingBooks temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        // Method that displays the list
        private void OutputList()
        {
            txtbxRandomValues.Items.Clear();
            foreach (ReplacingBooks item in booksList)
            {
                txtbxRandomValues.Items.Add(item.code.ToString("0.00") + " " + item.surname);
            }
        }

        // Method to sort and display the list
        private void SortAndDisplayList()
        {

            OutputList();
        }

        // Method to add to user selection list box
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtbxRandomValues.SelectedIndex > -1)
            {
                string selected = txtbxRandomValues.SelectedItem.ToString();
                txtbxUserOrders.Items.Add(selected);
                userSelectionList.Add(booksList[txtbxRandomValues.SelectedIndex]);
            }
            else
            {
                MessageBox.Show("Please select a value from the randomly generated ones", "Info");
            }
        }

        // Method that removes selected value from user selection list box
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtbxUserOrders.SelectedIndex > -1)
            {
                int index = txtbxUserOrders.SelectedIndex;
                userSelectionList.RemoveAt(index);
                txtbxUserOrders.Items.RemoveAt(index);
            }
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            if (userSelectionList.Count != 10)
            {
                MessageBox.Show("Please insert 10 Values", "Info");
                return;
            }

            bool isCorrectOrder = userSelectionList.SequenceEqual(booksList);

            if (!isCorrectOrder)
            {
                MessageBox.Show("All Values are Correct\n" + "Your Points is 100/100" + "\nWell Done!", "Info");
            }
            else
            {
                // Deduct points if user inputs the wrong order
                points -= 5;
                MessageBox.Show("Some values are not in the correct place\n" + "Your Current Score is " + points + "/100", "Info");
            }
        }

        private void homebtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
        }

    }
}
