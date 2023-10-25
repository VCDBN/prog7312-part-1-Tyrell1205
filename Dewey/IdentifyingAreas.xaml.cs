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
    /// Interaction logic for IdentifyingAreas.xaml
    /// </summary>
    public partial class IdentifyingAreas : Window
    {
        public List<string> mylist = new List<string>(); 

        public Dictionary<int, book> dictionaryBooks = new Dictionary<int, book>(); // sadly only is used to present the answers back to the user

        public static Random rnd = new Random();
        public int[] descriptions = {            // this array will now hold numbers 
            100 + rnd.Next(1,100),
            200 + rnd.Next(1, 100),
            300 + rnd.Next(1, 100),
            400 + rnd.Next(1, 100),
            500 + rnd.Next(1, 100),
            600 + rnd.Next(1, 100),
            700 + rnd.Next(1, 100),
           

        };
        public int point = 0; // variable to increase points, gamification feature

        book Book1 = new book() //book objects to work with the dictionary
        {
            Num = 0,
            Categories = ""

        };
        book Book2 = new book()
        {
            Num = 0,
            Categories = ""

        };
        book Book3 = new book()
        {
            Num = 0,
            Categories = ""

        };
        book Book4 = new book()
        {
            Num = 0,
            Categories = ""

        };
        public IdentifyingAreas()
        {
            InitializeComponent();
        }

        public class book // book class is the first step to get objects stored into the dictionationary
        {
            public int Num { get; set; }
            public string Categories { get; set; }
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            mylist.Add("Philo and Psycho"); // first thing will happen is to populate the list, this will be manual, and only 7 will do
            mylist.Add("Religion");
            mylist.Add("Social Sciences");
            mylist.Add("Languages");
            mylist.Add("Science");
            mylist.Add("Technology");
            mylist.Add("Arts and Recreation");

            foreach (object item in mylist) //add string popualted list to the listbox
            {
                lbOne_.Items.Add(item);
            }

            

            int index = rnd.Next(descriptions.Length);              // pick a random index in array
            desOne.Text = Convert.ToString(descriptions[index]);    // take the text of that index and add it to the respective description textbox
            for (int i = index; i < descriptions.Length - 1; i++)   // remove that index and it's text from the array
            {
                descriptions[i] = descriptions[i + 1];
            }
            Array.Resize(ref descriptions, descriptions.Length - 1);// resize the array as a new array


            int index2 = rnd.Next(descriptions.Length);
            desTwo.Text = Convert.ToString(descriptions[index2]);
            for (int i = index2; i < descriptions.Length - 1; i++)
            {
                descriptions[i] = descriptions[i + 1];
            }
            Array.Resize(ref descriptions, descriptions.Length - 1);


            int index3 = rnd.Next(descriptions.Length);             // repeat the above steps
            desThree.Text = Convert.ToString(descriptions[index3]);
            for (int i = index3; i < descriptions.Length - 1; i++)
            {
                descriptions[i] = descriptions[i + 1];
            }
            Array.Resize(ref descriptions, descriptions.Length - 1);


            int index4 = rnd.Next(descriptions.Length);
            desFour.Text = Convert.ToString(descriptions[index4]);

        }

        private void lbOne_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ansOne.Text == ansTwo.Text)                     // so if the 2 textboxes are both blank then add to the first textbox first
            {
                ansOne.Text = lbOne_.SelectedItem.ToString();
            }
            else if (ansTwo.Text == ansThree.Text)
            {
                ansTwo.Text = lbOne_.SelectedItem.ToString();   // through this method it was the only way to make clicking on items in the listbox to appear in the textbox, with some sense of controll

            }
            else if (ansThree.Text == ansFour.Text)
            {
                ansThree.Text = lbOne_.SelectedItem.ToString(); 

            }
            else if (ansFour.Text != ansOne.Text)
            {
                ansFour.Text = lbOne_.SelectedItem.ToString();

            }
        }

        private void subbtn_Click(object sender, RoutedEventArgs e)
        {
            Book1.Num = Convert.ToInt32(desOne.Text);  // upon the btn click the book objects Num's and categorydescriptions are populated with the textbox texts
            Book1.Categories = ansOne.Text;
            dictionaryBooks.Add(Book1.Num, Book1);

            Book2.Num = Convert.ToInt32(desTwo.Text);// each book object has a respective number textbox and a description textbox
            Book2.Categories = ansTwo.Text;
            dictionaryBooks.Add(Book2.Num, Book2);

            Book3.Num = Convert.ToInt32(desThree.Text); // that popualated book is then stored in a dictionary, and will be used as feedback to the user in the submit btn
            Book3.Categories = ansThree.Text;
            dictionaryBooks.Add(Book3.Num, Book3);


            Book4.Num = Convert.ToInt32(desFour.Text);
            Book4.Categories = ansFour.Text;
            dictionaryBooks.Add(Book4.Num, Book4);


            foreach (KeyValuePair<int, book> bookkeyValuePair in dictionaryBooks) //display the stored dictonary data to the user
            {
                book bk = bookkeyValuePair.Value;
                string a = bk.Num + " " + bk.Categories;
                MessageBox.Show(a);
            }


            //--------------//


            if (Book1.Num < 200 && Book1.Num > 100 && Book1.Categories == "Philo and Psycho" || // due to randomness each textbox will check for a possible correct answer
                Book1.Num < 300 && Book1.Num > 200 && Book1.Categories == "Religion" ||         // updated score checking system
                Book1.Num < 400 && Book1.Num > 300 && Book1.Categories == "Social Sciences" ||
                Book1.Num < 500 && Book1.Num > 400 && Book1.Categories == "Languages" ||
                Book1.Num < 600 && Book1.Num > 500 && Book1.Categories == "Science" ||
                Book1.Num < 700 && Book1.Num > 600 && Book1.Categories == "Technology" ||
                Book1.Num < 800 && Book1.Num > 700 && Book1.Categories == "Arts and Recreation"
              )
            {
                point = point + 1; // when a possible condition is found incrase the score varible by 1, gamification feature
            }
            if (Book2.Num < 200 && Book2.Num > 100 && Book2.Categories == "Philo and Psycho" ||
                Book2.Num < 300 && Book2.Num > 200 && Book2.Categories == "Religion" ||
                Book2.Num < 400 && Book2.Num > 300 && Book2.Categories == "Social Sciences" ||
                Book2.Num < 500 && Book2.Num > 400 && Book2.Categories == "Languages" ||
                Book2.Num < 600 && Book2.Num > 500 && Book2.Categories == "Science" ||
                Book2.Num < 700 && Book2.Num > 600 && Book2.Categories == "Technology" ||
                Book2.Num < 800 && Book2.Num > 700 && Book2.Categories == "Arts and Recreation"
              )
            {
                point = point + 1;
            }
            if (Book3.Num < 200 && Book3.Num > 100 && Book3.Categories == "Philo and Psycho" ||
                Book3.Num < 300 && Book3.Num > 200 && Book3.Categories == "Religion" ||
                Book3.Num < 400 && Book3.Num > 300 && Book3.Categories == "Social Sciences" ||
                Book3.Num < 500 && Book3.Num > 400 && Book3.Categories == "Languages" ||
                Book3.Num < 600 && Book3.Num > 500 && Book3.Categories == "Science" ||
                Book3.Num < 700 && Book3.Num > 600 && Book3.Categories == "Technology" ||
                Book3.Num < 800 && Book3.Num > 700 && Book3.Categories == "Arts and Recreation"
              )
            {
                point = point + 1;
            }
            if (Book4.Num < 200 && Book4.Num > 100 && Book4.Categories == "Philo and Psycho" ||
                Book4.Num < 300 && Book4.Num > 200 && Book4.Categories == "Religion" ||
                Book4.Num < 400 && Book4.Num > 300 && Book4.Categories == "Social Sciences" ||
                Book4.Num < 500 && Book4.Num > 400 && Book4.Categories == "Languages" ||
                Book4.Num < 600 && Book4.Num > 500 && Book4.Categories == "Science" ||
                Book4.Num < 700 && Book4.Num > 600 && Book4.Categories == "Technology" ||
                Book4.Num < 800 && Book4.Num > 700 && Book4.Categories == "Arts and Recreation"
              )
            {
                point = point + 1;
            }

            if (point == 4)
            {
                MessageBox.Show("You scored " + point + " points out of 4\n" + point + "/4" + "\nWell done, maximum points achieved!"); // message box options to display the users score
            }
            else
            {
                MessageBox.Show("You scored " + point + " points out of 4\n" + point + "/4");
            }
        }

        private void clearansbtn_Click(object sender, RoutedEventArgs e)
        {
            // incase a mistake is made and the user wants to reenter answers
            ansFour.Text = "";
            ansOne.Text = "";
            ansTwo.Text = "";
            ansThree.Text = "";
        }

        private void replaybtn_Click(object sender, RoutedEventArgs e)
        {
            //back to main menu to play again
            this.Hide();
            MainWindow IA = new MainWindow();
            IA.Show();
        }

    }
}
