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
using static Dewey.IdentifyingAreas;

namespace Dewey
{
    /// <summary>
    /// Interaction logic for AlternateIA.xaml
    /// </summary>
    public partial class AlternateIA : Window
    {
        public List<int> mylist = new List<int>(); // the list os only to be randomised and read off by the listbox

        public string[] descriptions = { "Philo and Psycho", "Religion", "Social Sciences", "Languages", "Science", "Technology", "Arts and Recre" }; //the 4 questions to be randomised to change questions, when presented (left it at for due to lack of will power)

        public Dictionary<int, book> dictionaryBooks = new Dictionary<int, book>(); // sadly only is used to present the answers back to the user

        public int point = 0; // variable to increase to repre points

        book Book1 = new book() //book objects to work with the dictionary
        {
            Num = 0,
            Categorydes = ""

        };
        book Book2 = new book()
        {
            Num = 0,
            Categorydes = ""

        };
        book Book3 = new book()
        {
            Num = 0,
            Categorydes = ""

        };
        book Book4 = new book()
        {
            Num = 0,
            Categorydes = ""

        };
        public AlternateIA()
        {
            InitializeComponent();
        }

        public class book // book class is the first step to get objects stored into the dictionationary
        {
            public int Num { get; set; }
            public string Categorydes { get; set; }
        }

        void shuffle() // code attribution: https://youtu.be/EvPVtKryspY for shuffling a list//
        {
            int lastIndex = mylist.Count() - 1;
            while (lastIndex > 0)
            {
                int tempValue = mylist[lastIndex];
                int randomIndex = new Random().Next(0, lastIndex);
                mylist[lastIndex] = mylist[randomIndex];
                mylist[randomIndex] = tempValue;
                lastIndex--;
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();


            ////////random answers/////////

            //for (int i = 0; i < 3; i++) // add 3 randome wrong answers
            //{
            //    mylist.Add(rnd.Next(500, 1000));
            //}
            mylist.Add(100 + rnd.Next(1, 100)); // add 4 grunateed correct answers to score points, use randome calcuations to make the numbers look randomly generated
            mylist.Add(200 + rnd.Next(1, 100));
            mylist.Add(300 + rnd.Next(1, 100));
            mylist.Add(400 + rnd.Next(1, 100));
            mylist.Add(500 + rnd.Next(1, 100));
            mylist.Add(600 + rnd.Next(1, 100));
            mylist.Add(700 + rnd.Next(1, 100)); // all the categories from the image can't be here, BECAUSE, there are 10 catgories but the poe wants 7 possible answers (3 of which are incorrect) hence there must be 4 answers that are guranteed to match with the chosen questions. to further explain, what if: the first 4 questions are chosen, but the 7 ansers started from 300 onwards, there is a chance a question one have us 1/4 gurnted answer, POINT MADE!!!

            shuffle(); //shuffle the list to add randomness

            foreach (object item in mylist)
            {
                lbOne.Items.Add(item);
            }


            ////////random questions/////////
            // all this below so the randomness does not pick the same thing twice

            int index = rnd.Next(descriptions.Length);              // pick a random index in array
            desOne.Text = descriptions[index];                      // take the text of that index and add it to the respective description textbox
            for (int i = index; i < descriptions.Length - 1; i++)   // remove that index and it's text from the array
            {
                descriptions[i] = descriptions[i + 1];
            }
            Array.Resize(ref descriptions, descriptions.Length - 1);// resize the array as a new array


            int index2 = rnd.Next(descriptions.Length);
            desTwo.Text = descriptions[index2];                     // replay error 2, if error one doesnt happen then this happens
            for (int i = index2; i < descriptions.Length - 1; i++)
            {
                descriptions[i] = descriptions[i + 1];
            }
            Array.Resize(ref descriptions, descriptions.Length - 1);


            int index3 = rnd.Next(descriptions.Length);             // repat the above steps
            desThree.Text = descriptions[index3];
            for (int i = index3; i < descriptions.Length - 1; i++)
            {
                descriptions[i] = descriptions[i + 1];
            }
            Array.Resize(ref descriptions, descriptions.Length - 1);


            int index4 = rnd.Next(descriptions.Length);
            desFour.Text = descriptions[index4];                    // the array should be shortened to one item at this/last point
        }

        private void subbtn_Click(object sender, RoutedEventArgs e)
        {
            Book1.Num = Convert.ToInt32(ansOne.Text); // upon the btn click the book objects Num's and categorydescriptions are populated with the textbox texts
            Book1.Categorydes = desOne.Text;
            dictionaryBooks.Add(Book1.Num, Book1);

            Book2.Num = Convert.ToInt32(ansTwo.Text); // each book object has a respective number textbox and a description textbox
            Book2.Categorydes = desTwo.Text;
            dictionaryBooks.Add(Book2.Num, Book2);

            Book3.Num = Convert.ToInt32(ansThree.Text); // that popualated book is then stored in a dictionary, and will be used as feedback to the user in the submit btn
            Book3.Categorydes = desThree.Text;
            dictionaryBooks.Add(Book3.Num, Book3);


            Book4.Num = Convert.ToInt32(ansFour.Text);
            Book4.Categorydes = desFour.Text;
            dictionaryBooks.Add(Book4.Num, Book4);


            foreach (KeyValuePair<int, book> bookkeyValuePair in dictionaryBooks) //display the stored dictonary data to the user
            {
                book bk = bookkeyValuePair.Value;
                string a = bk.Num + " " + bk.Categorydes;
                MessageBox.Show(a);
            }

            if (Book1.Num < 200 && Book1.Num > 100 && Book1.Categorydes == "Philo and Psycho" || // due to randomness each textbox will check for a possible correct answer
                Book1.Num < 300 && Book1.Num > 200 && Book1.Categorydes == "Religion" ||
                Book1.Num < 400 && Book1.Num > 300 && Book1.Categorydes == "Social Sciences" ||
                Book1.Num < 500 && Book1.Num > 400 && Book1.Categorydes == "Languages" ||
                Book1.Num < 600 && Book1.Num > 500 && Book1.Categorydes == "Science" ||
                Book1.Num < 700 && Book1.Num > 600 && Book1.Categorydes == "Technology" ||
                Book1.Num < 800 && Book1.Num > 700 && Book1.Categorydes == "Arts and Recre"
              )
            {
                point = point + 1; // when a possible condition is found incrase the score varible by 1
            }
            if (Book2.Num < 200 && Book2.Num > 100 && Book2.Categorydes == "Philo and Psycho" ||
                Book2.Num < 300 && Book2.Num > 200 && Book2.Categorydes == "Religion" ||
                Book2.Num < 400 && Book2.Num > 300 && Book2.Categorydes == "Social Sciences" ||
                Book2.Num < 500 && Book2.Num > 400 && Book2.Categorydes == "Languages" ||
                Book2.Num < 600 && Book2.Num > 500 && Book2.Categorydes == "Science" ||
                Book2.Num < 700 && Book2.Num > 600 && Book2.Categorydes == "Technology" ||
                Book2.Num < 800 && Book2.Num > 700 && Book2.Categorydes == "Arts and Recre"
              )
            {
                point = point + 1;
            }
            if (Book3.Num < 200 && Book3.Num > 100 && Book3.Categorydes == "Philo and Psycho" ||
                Book3.Num < 300 && Book3.Num > 200 && Book3.Categorydes == "Religion" ||
                Book3.Num < 400 && Book3.Num > 300 && Book3.Categorydes == "Social Sciences" ||
                Book3.Num < 500 && Book3.Num > 400 && Book3.Categorydes == "Languages" ||
                Book3.Num < 600 && Book3.Num > 500 && Book3.Categorydes == "Science" ||
                Book3.Num < 700 && Book3.Num > 600 && Book3.Categorydes == "Technology" ||
                Book3.Num < 800 && Book3.Num > 700 && Book3.Categorydes == "Arts and Recre"
              )
            {
                point = point + 1;
            }
            if (Book4.Num < 200 && Book4.Num > 100 && Book4.Categorydes == "Philo and Psycho" ||
                Book4.Num < 300 && Book4.Num > 200 && Book4.Categorydes == "Religion" ||
                Book4.Num < 400 && Book4.Num > 300 && Book4.Categorydes == "Social Sciences" ||
                Book4.Num < 500 && Book4.Num > 400 && Book4.Categorydes == "Languages" ||
                Book4.Num < 600 && Book4.Num > 500 && Book4.Categorydes == "Science" ||
                Book4.Num < 700 && Book4.Num > 600 && Book4.Categorydes == "Technology" ||
                Book4.Num < 800 && Book4.Num > 700 && Book4.Categorydes == "Arts and Recre"
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

        private void lbOne_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ansOne.Text == ansTwo.Text)                  // so if the 2 textboxes are both blank then add to the first textbox first
            {
                ansOne.Text = lbOne.SelectedItem.ToString(); // reply error 1
            }
            else if (ansTwo.Text == ansThree.Text)
            {
                ansTwo.Text = lbOne.SelectedItem.ToString(); // through this method it was the only way to make clicking on items in the listbox to appear in the textbox, with some sense of controll

            }
            else if (ansThree.Text == ansFour.Text)
            {
                ansThree.Text = lbOne.SelectedItem.ToString(); // forcing these textboxes to be answered from top to bottom was the only way

            }
            else if (ansFour.Text != ansOne.Text)
            {
                ansFour.Text = lbOne.SelectedItem.ToString();

            }
        }

        private void replaybtn_Click(object sender, RoutedEventArgs e)
        {
            
            this.Hide();
            IdentifyingAreas IA = new IdentifyingAreas();
            IA.Show();
        }

        private void clearansbtn_Click(object sender, RoutedEventArgs e)
        {
            // insase a mistake is made and the user wants to reenter answers
            ansFour.Text = "";
            ansOne.Text = "";
            ansTwo.Text = "";
            ansThree.Text = "";
        }

        private void homebtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow IA = new MainWindow();   
            IA.Show();  
        }
    }
}
    

