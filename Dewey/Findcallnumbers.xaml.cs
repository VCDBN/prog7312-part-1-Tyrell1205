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
    /// Interaction logic for Findcallnumbers.xaml
    /// </summary>
    public partial class Findcallnumbers : Window
    {
        public string[] descriptions = { //this will be the array of our given question, 1 third level description for every 1st level catgory
            "Knowledge",
            "Ontology",
            "Old Testament",
            "Labour economics",
            "French writing system & phonology",
            "Geology, hydrology, meteorology",
            "Industrial chemicals technology",
            "Techniques, equipment, materials",
            "Old and early French to 1400850 Italian, Romanian, Rhaeto-Romanic",
            "Not assigned or no longer used" };

        public List<string> mylist = new List<string>();        //a list that will hold the avaliable answers
        public List<string> fourAnswers = new List<string>();   // this will be a list that hold the '4 only' answers 

        public int point = 100; //the point meter
        public Findcallnumbers()
        {
            InitializeComponent();
        }
        void shuffle() //a list shuffle. Code was developed with the help of FallenWorldStudios on youtube, you can find it at: https://youtu.be/EvPVtKryspY?si=IGhG1BCDybleMU18
        {
            int lastIndex = mylist.Count() - 1;
            while (lastIndex > 0)
            {
                string tempValue = mylist[lastIndex];
                int randomIndex = new Random().Next(0, lastIndex);
                mylist[lastIndex] = mylist[randomIndex];
                mylist[randomIndex] = Convert.ToString(tempValue);
                lastIndex--;
            }
        }

        void shufflefourAnswers() //a list shuffle for the 4 only answers that will come into play later
        {
            int lastIndex = fourAnswers.Count() - 1;
            while (lastIndex > 0)
            {
                string tempValue = fourAnswers[lastIndex];
                int randomIndex = new Random().Next(0, lastIndex);
                fourAnswers[lastIndex] = fourAnswers[randomIndex];
                fourAnswers[randomIndex] = Convert.ToString(tempValue);
                lastIndex--;
            }
        }

        private void startbtn_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            //populating the possible answers that come from the third level
            descriptiontb.Text = descriptions[rnd.Next(0, 9)];                  // at this part provide the user with a random question from our array of possible questions


            if (descriptiontb.Text == "Knowledge") //inside this if, is making sure that if we get the spefic question (in this case knowledge) the respective to the subject's following will show
            {
                fourAnswers.Add("000 General Knowledge"); //THIS HERE is where we make sure we get the answer that works with the given description in the if-statment/given sernario to the user
                mylist.Add("100 Philo and Psycho");
                mylist.Add("200 Religion");
                mylist.Add("300 Social Sciences");
                mylist.Add("400 Languages");
                mylist.Add("500 Science");
                mylist.Add("600 Technology");
                mylist.Add("700 Arts and Recreation");
                mylist.Add("800 Literature");
                mylist.Add("900 History & Geography");

                shuffle();
                for (int i = 0; i < 3; i++)
                {
                    fourAnswers.Add(mylist[i]); // then add the 3 rest random 1st level answers to the fouranswers array to make that an array witha guranteed answers for the situation
                }

                shufflefourAnswers();
                foreach (object item in fourAnswers)
                {
                    listbox1.Items.Add(item); // have the list box read of the fouranswers array
                }
            }

            //----------------------------2----------------------------------//
            if (descriptiontb.Text == "Ontology") //repeat for every option we have in the array, and if-statment/secure an answer, for the description
            {
                mylist.Add("000 General Knowledge");
                fourAnswers.Add("100 Philo and Psycho");
                mylist.Add("200 Religion");
                mylist.Add("300 Social Sciences");
                mylist.Add("400 Languages");
                mylist.Add("500 Science");
                mylist.Add("600 Technology");
                mylist.Add("700 Arts and Recreation");
                mylist.Add("800 Literature");
                mylist.Add("900 History & Geography");

                shuffle();
                for (int i = 0; i < 3; i++)
                {
                    fourAnswers.Add(mylist[i]);
                }

                shufflefourAnswers();
                foreach (object item in fourAnswers)
                {
                    listbox1.Items.Add(item);
                }
            }

            //----------------------------3----------------------------------//
            if (descriptiontb.Text == "Old Testament") //then do it again, untill all the array answers have been covered
            {
                mylist.Add("000 General Knowledge");
                mylist.Add("100 Philo and Psycho");
                fourAnswers.Add("200 Religion");
                mylist.Add("300 Social Sciences");
                mylist.Add("400 Languages");
                mylist.Add("500 Science");
                mylist.Add("600 Technology");
                mylist.Add("700 Arts and Recreation");
                mylist.Add("800 Literature");
                mylist.Add("900 History & Geography");

                shuffle();
                for (int i = 0; i < 3; i++)
                {
                    fourAnswers.Add(mylist[i]);
                }

                shufflefourAnswers();
                foreach (object item in fourAnswers)
                {
                    listbox1.Items.Add(item);
                }
            }



            //----------------------------4----------------------------------//
            if (descriptiontb.Text == "Labour economics")
            {
                mylist.Add("000 General Knowledge");
                mylist.Add("100 Philo and Psycho");
                mylist.Add("200 Religion");
                fourAnswers.Add("300 Social Sciences");
                mylist.Add("400 Languages");
                mylist.Add("500 Science");
                mylist.Add("600 Technology");
                mylist.Add("700 Arts and Recreation");
                mylist.Add("800 Literature");
                mylist.Add("900 History & Geography");

                shuffle();
                for (int i = 0; i < 3; i++)
                {
                    fourAnswers.Add(mylist[i]);
                }

                shufflefourAnswers();
                foreach (object item in fourAnswers)
                {
                    listbox1.Items.Add(item);
                }
            }



            //----------------------------5----------------------------------//
            if (descriptiontb.Text == "French writing system & phonology")
            {
                mylist.Add("000 General Knowledge");
                mylist.Add("100 Philo and Psycho");
                mylist.Add("200 Religion");
                mylist.Add("300 Social Sciences");
                fourAnswers.Add("400 Languages");
                mylist.Add("500 Science");
                mylist.Add("600 Technology");
                mylist.Add("700 Arts and Recreation");
                mylist.Add("800 Literature");
                mylist.Add("900 History & Geography");

                shuffle();
                for (int i = 0; i < 3; i++)
                {
                    fourAnswers.Add(mylist[i]);
                }

                shufflefourAnswers();
                foreach (object item in fourAnswers)
                {
                    listbox1.Items.Add(item);
                }
            }

            //----------------------------6----------------------------------//
            if (descriptiontb.Text == "Geology, hydrology, meteorology")
            {
                mylist.Add("000 General Knowledge");
                mylist.Add("100 Philo and Psycho");
                mylist.Add("200 Religion");
                mylist.Add("300 Social Sciences");
                mylist.Add("400 Languages");
                fourAnswers.Add("500 Science");
                mylist.Add("600 Technology");
                mylist.Add("700 Arts and Recreation");
                mylist.Add("800 Literature");
                mylist.Add("900 History & Geography");

                shuffle();
                for (int i = 0; i < 3; i++)
                {
                    fourAnswers.Add(mylist[i]);
                }

                shufflefourAnswers();
                foreach (object item in fourAnswers)
                {
                    listbox1.Items.Add(item);
                }
            }



            //----------------------------7----------------------------------//
            if (descriptiontb.Text == "Industrial chemicals technology")
            {
                mylist.Add("000 General Knowledge");
                mylist.Add("100 Philo and Psycho");
                mylist.Add("200 Religion");
                mylist.Add("300 Social Sciences");
                mylist.Add("400 Languages");
                mylist.Add("500 Science");
                fourAnswers.Add("600 Technology");
                mylist.Add("700 Arts and Recreation");
                mylist.Add("800 Literature");
                mylist.Add("900 History & Geography");

                shuffle();
                for (int i = 0; i < 3; i++)
                {
                    fourAnswers.Add(mylist[i]);
                }

                shufflefourAnswers();
                foreach (object item in fourAnswers)
                {
                    listbox1.Items.Add(item);
                }
            }



            //----------------------------8----------------------------------//
            if (descriptiontb.Text == "Techniques, equipment, materials")
            {
                mylist.Add("000 General Knowledge");
                mylist.Add("100 Philo and Psycho");
                mylist.Add("200 Religion");
                mylist.Add("300 Social Sciences");
                mylist.Add("400 Languages");
                mylist.Add("500 Science");
                mylist.Add("600 Technology");
                fourAnswers.Add("700 Arts and Recreation");
                mylist.Add("800 Literature");
                mylist.Add("900 History & Geography");

                shuffle();
                for (int i = 0; i < 3; i++)
                {
                    fourAnswers.Add(mylist[i]);
                }

                shufflefourAnswers();
                foreach (object item in fourAnswers)
                {
                    listbox1.Items.Add(item);
                }
            }



            //----------------------------9----------------------------------//
            if (descriptiontb.Text == "Old and early French to 1400850 Italian, Romanian, Rhaeto-Romanic")
            {
                mylist.Add("000 General Knowledge");
                mylist.Add("100 Philo and Psycho");
                mylist.Add("200 Religion");
                mylist.Add("300 Social Sciences");
                mylist.Add("400 Languages");
                mylist.Add("500 Science");
                mylist.Add("600 Technology");
                mylist.Add("700 Arts and Recreation");
                fourAnswers.Add("800 Literature");
                mylist.Add("900 History & Geography");

                shuffle();
                for (int i = 0; i < 3; i++)
                {
                    fourAnswers.Add(mylist[i]);
                }

                shufflefourAnswers();
                foreach (object item in fourAnswers)
                {
                    listbox1.Items.Add(item);
                }
            }



            //----------------------------10----------------------------------//
            if (descriptiontb.Text == "Not assigned or no longer used")
            {
                mylist.Add("000 General Knowledge");
                mylist.Add("100 Philo and Psycho");
                mylist.Add("200 Religion");
                mylist.Add("300 Social Sciences");
                mylist.Add("400 Languages");
                mylist.Add("500 Science");
                mylist.Add("600 Technology");
                mylist.Add("700 Arts and Recreation");
                mylist.Add("800 Literature");
                fourAnswers.Add("900 History & Geography");

                shuffle();
                for (int i = 0; i < 3; i++)
                {
                    fourAnswers.Add(mylist[i]);
                }

                shufflefourAnswers();
                foreach (object item in fourAnswers)
                {
                    listbox1.Items.Add(item);
                }
            }
        }

        private void listbox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            answertb.Text = listbox1.SelectedItem.ToString(); //how the user will select their answer(s), by picking an item from the list box
        }

        private void submitbtn_Click(object sender, RoutedEventArgs e)
        {
            if (answertb.Text == "000 General Knowledge" && descriptiontb.Text == "Knowledge") //this if statment is here to cover a possible sernario, hence if the first answer the user gave was correct then do this, for the same sernario
            {
                MessageBox.Show("correct! do you know what sub-category it belongs in");

                mylist.Clear();
                fourAnswers.Clear();
                answertb.Text = "";

                //populate the list box with the chosen respective level 2 options of the picked level 1 answer
                fourAnswers.Add("010 Bibliographies & catalogues");
                mylist.Add("020 Library & information sciences");
                mylist.Add("030 General encyclopaedic works");
                mylist.Add("050 General serials & their indexes");
                mylist.Add("060 General organizations & museums");
                mylist.Add("070 News media, journalism, publishing");
                mylist.Add("080 General collections");
                mylist.Add("090 Manuscripts & rare books");

                shuffle();
                for (int i = 0; i < 3; i++)
                {
                    fourAnswers.Add(mylist[i]);
                }

                shufflefourAnswers();
                foreach (object item in fourAnswers)
                {
                    listbox2.Items.Add(item); // same procedure to make sure the 4 only answers are only 4 and have 1 guranteed answers avaliable for this possible situation
                }
            }
            if (answertb.Text == "010 Bibliographies & catalogues" && descriptiontb.Text == "Knowledge") //having the description match the sub category/2nd level answers. this if statment can only be achieved if the first if statment was a success 
            {
                MessageBox.Show("WOW! ALL MATCH, ALL CORRECT \n your answering is " + point + "% accurate"); //in this case, the users score of answer accuracy than a point build up

            }

            if (answertb.Text != "000 General Knowledge" && answertb.Text != "010 Bibliographies & catalogues" && answertb.Text != "" && descriptiontb.Text == "Knowledge")
            {
                MessageBox.Show("oops, that doesn't seem right. try again."); //if statments for ther sernario's wrong answers
                point = point - 10; //a accuracy point deduction to reflect how the user played
            }





            //----------------------------2----------------------------------//
            if (answertb.Text == "100 Philo and Psycho" && descriptiontb.Text == "Ontology") // repeat the if statments for all possible sernarios
            {
                MessageBox.Show("correct! do you know what sub-category it belongs in");

                mylist.Clear();
                fourAnswers.Clear();
                answertb.Text = "";

                fourAnswers.Add("110 Metaphysics");
                mylist.Add("120 Epistemology, causation, humankind");
                mylist.Add("130 Paranormal phenomena");
                mylist.Add("140 Specific philosophical schools");
                mylist.Add("150 Psychology");
                mylist.Add("160 Logic");
                mylist.Add("170 Ethics (Moral philosophy)");
                mylist.Add("180 Ancient, medieval, Oriental philosophy");
                mylist.Add("190 Modern Western philosophy");


                shuffle();
                for (int i = 0; i < 3; i++)
                {
                    fourAnswers.Add(mylist[i]);
                }

                shufflefourAnswers();
                foreach (object item in fourAnswers)
                {
                    listbox2.Items.Add(item);
                }
            }
            if (answertb.Text == "110 Metaphysics" && descriptiontb.Text == "Ontology")
            {
                MessageBox.Show("WOW! ALL MATCH, ALL CORRECT \n your answering is " + point + "% accurate");
            }

            if (answertb.Text != "100 Philo and Psycho" && answertb.Text != "110 Metaphysics" && answertb.Text != "" && descriptiontb.Text == "Ontology")
            {
                MessageBox.Show("oops, that doesn't seem right. try again.");
                point = point - 10;
            }



            //----------------------------3----------------------------------//
            if (answertb.Text == "200 Religion" && descriptiontb.Text == "Old Testament")
            {
                MessageBox.Show("correct! do you know what sub-category it belongs in");

                mylist.Clear();
                fourAnswers.Clear();
                answertb.Text = "";

                mylist.Add("210 Natural theology");
                fourAnswers.Add("220 Bible");
                mylist.Add("230 Christian Theology");
                mylist.Add("240 Christian moral & devotional theology");
                mylist.Add("250 Christian orders & local churches");
                mylist.Add("260 Christian social theology");
                mylist.Add("270 Christian church history");
                mylist.Add("280 Christian denominations & sects");
                mylist.Add("290 Other and comparative religions");


                shuffle();
                for (int i = 0; i < 3; i++)
                {
                    fourAnswers.Add(mylist[i]);
                }

                shufflefourAnswers();
                foreach (object item in fourAnswers)
                {
                    listbox2.Items.Add(item);
                }
            }
            if (answertb.Text == "220 Bible" && descriptiontb.Text == "Old Testament")
            {
                MessageBox.Show("WOW! ALL MATCH, ALL CORRECT \n your answering is " + point + "% accurate");
            }

            if (answertb.Text != "200 Religion" && answertb.Text != "220 Bible" && answertb.Text != "" && descriptiontb.Text == "Old Testament")
            {
                MessageBox.Show("oops, that doesn't seem right. try again.");
                point = point - 10;
            }


            //----------------------------4----------------------------------//
            if (answertb.Text == "300 Social Sciences" && descriptiontb.Text == "Labour economics")
            {
                MessageBox.Show("correct! do you know what sub-category it belongs in");

                mylist.Clear();
                fourAnswers.Clear();
                answertb.Text = "";

                mylist.Add("310 General statistics");
                mylist.Add("320 Political sciences");
                fourAnswers.Add("330 Economics");
                mylist.Add("340 Law");
                mylist.Add("350 Public administration");
                mylist.Add("360 Social welfare");
                mylist.Add("370 Education");
                mylist.Add("380 Commerce, communications, transport");
                mylist.Add("390 Customs, etiquette, folklore");


                shuffle();
                for (int i = 0; i < 3; i++)
                {
                    fourAnswers.Add(mylist[i]);
                }

                shufflefourAnswers();
                foreach (object item in fourAnswers)
                {
                    listbox2.Items.Add(item);
                }
            }
            if (answertb.Text == "330 Economics" && descriptiontb.Text == "Labour economics")
            {
                MessageBox.Show("WOW! ALL MATCH, ALL CORRECT \n your answering is " + point + "% accurate");
            }

            if (answertb.Text != "300 Social Sciences" && answertb.Text != "330 Economics" && answertb.Text != "" && descriptiontb.Text == "Labour economics")
            {
                MessageBox.Show("oops, that doesn't seem right. try again.");
                point = point - 10;
            }



            //----------------------------5----------------------------------//
            if (answertb.Text == "400 Languages" && descriptiontb.Text == "French writing system & phonology")
            {
                MessageBox.Show("correct! do you know what sub-category it belongs in");

                mylist.Clear();
                fourAnswers.Clear();
                answertb.Text = "";

                mylist.Add("410 Linguistics");
                mylist.Add("420 English & Old English");
                mylist.Add("430 Germanic languages, i.e., German");
                fourAnswers.Add("440 Romance languages, i.e., French");
                mylist.Add("450 Italian, Romanian languages");
                mylist.Add("460 Spanish & Portuguese languages");
                mylist.Add("470 Italic languages, i.e., Latin");
                mylist.Add("480 Hellenic languages, i.e., Classical Greek");
                mylist.Add("490 Other languages");


                shuffle();
                for (int i = 0; i < 3; i++)
                {
                    fourAnswers.Add(mylist[i]);
                }

                shufflefourAnswers();
                foreach (object item in fourAnswers)
                {
                    listbox2.Items.Add(item);
                }
            }
            if (answertb.Text == "440 Romance languages, i.e., French" && descriptiontb.Text == "French writing system & phonology")
            {
                MessageBox.Show("WOW! ALL MATCH, ALL CORRECT \n your answering is " + point + "% accurate");
            }

            if (answertb.Text != "400 Languages" && answertb.Text != "440 Romance languages, i.e., French" && answertb.Text != "" && descriptiontb.Text == "French writing system & phonology")
            {
                MessageBox.Show("oops, that doesn't seem right. try again.");
                point = point - 10;
            }


            //----------------------------6----------------------------------//
            if (answertb.Text == "500 Science" && descriptiontb.Text == "Geology, hydrology, meteorology")
            {
                MessageBox.Show("correct! do you know what sub-category it belongs in");

                mylist.Clear();
                fourAnswers.Clear();
                answertb.Text = "";

                mylist.Add("510 Mathematics");
                mylist.Add("520 Astronomy & allied sciences");
                mylist.Add("530 Physics");
                mylist.Add("540 Chemistry & allied sciences");
                fourAnswers.Add("550 Earth sciences");
                mylist.Add("560 Palaeontology, Paleozoology");
                mylist.Add("570 Life Sciences");
                mylist.Add("580 Botanical sciences");
                mylist.Add("590 Zoological sciences");


                shuffle();
                for (int i = 0; i < 3; i++)
                {
                    fourAnswers.Add(mylist[i]);
                }

                shufflefourAnswers();
                foreach (object item in fourAnswers)
                {
                    listbox2.Items.Add(item);
                }
            }
            if (answertb.Text == "550 Earth sciences" && descriptiontb.Text == "Geology, hydrology, meteorology")
            {
                MessageBox.Show("WOW! ALL MATCH, ALL CORRECT \n your answering is " + point + "% accurate");
            }

            if (answertb.Text != "500 Science" && answertb.Text != "550 Earth sciences" && answertb.Text != "" && descriptiontb.Text == "Geology, hydrology, meteorology")
            {
                MessageBox.Show("oops, that doesn't seem right. try again.");
                point = point - 10;
            }



            //----------------------------7----------------------------------//
            if (answertb.Text == "600 Technology" && descriptiontb.Text == "Industrial chemicals technology")
            {
                MessageBox.Show("correct! do you know what sub-category it belongs in");

                mylist.Clear();
                fourAnswers.Clear();
                answertb.Text = "";

                mylist.Add("610 Medical sciences");
                mylist.Add("620 Engineering & allied sciences");
                mylist.Add("630 Agriculture");
                mylist.Add("640 Home economics & family living");
                mylist.Add("650 Management & auxiliary servicess");
                fourAnswers.Add("660 Chemical engineering");
                mylist.Add("670 Manufacturing");
                mylist.Add("680 Manufacture for specific uses");
                mylist.Add("690 Buildings");


                shuffle();
                for (int i = 0; i < 3; i++)
                {
                    fourAnswers.Add(mylist[i]);
                }

                shufflefourAnswers();
                foreach (object item in fourAnswers)
                {
                    listbox2.Items.Add(item);
                }
            }
            if (answertb.Text == "660 Chemical engineering" && descriptiontb.Text == "Industrial chemicals technology")
            {
                MessageBox.Show("WOW! ALL MATCH, ALL CORRECT \n your answering is " + point + "% accurate");
            }

            if (answertb.Text != "600 Technology" && answertb.Text != "660 Chemical engineering" && answertb.Text != "" && descriptiontb.Text == "Industrial chemicals technology")
            {
                MessageBox.Show("oops, that doesn't seem right. try again.");
                point = point - 10;
            }


            //----------------------------8----------------------------------//
            if (answertb.Text == "700 Arts and Recreation" && descriptiontb.Text == "Techniques, equipment, materials")
            {
                MessageBox.Show("correct! do you know what sub-category it belongs in");

                mylist.Clear();
                fourAnswers.Clear();
                answertb.Text = "";

                mylist.Add("710 Civic & landscape art");
                mylist.Add("720 Architecture");
                mylist.Add("730 Plastic arts");
                mylist.Add("740 Drawing & decorative arts");
                mylist.Add("750 Painting & paintings");
                mylist.Add("760 Graphic arts");
                fourAnswers.Add("770 Photography & photographs");
                mylist.Add("780 Music");
                mylist.Add("790 Recreational & performing arts");


                shuffle();
                for (int i = 0; i < 3; i++)
                {
                    fourAnswers.Add(mylist[i]);
                }

                shufflefourAnswers();
                foreach (object item in fourAnswers)
                {
                    listbox2.Items.Add(item);
                }
            }
            if (answertb.Text == "770 Photography & photographs" && descriptiontb.Text == "Techniques, equipment, materials")
            {
                MessageBox.Show("WOW! ALL MATCH, ALL CORRECT \n your answering is " + point + "% accurate");
            }

            if (answertb.Text != "700 Arts and Recreation" && answertb.Text != "770 Photography & photographs" && answertb.Text != "" && descriptiontb.Text == "Techniques, equipment, materials")
            {
                MessageBox.Show("oops, that doesn't seem right. try again.");
                point = point - 10;
            }



            //----------------------------9----------------------------------//
            if (answertb.Text == "800 Literature" && descriptiontb.Text == "Old and early French to 1400850 Italian, Romanian, Rhaeto-Romanic")
            {
                MessageBox.Show("correct! do you know what sub-category it belongs in");

                mylist.Clear();
                fourAnswers.Clear();
                answertb.Text = "";

                mylist.Add("810 American literature in English");
                mylist.Add("820 English and Old English literaturee");
                mylist.Add("830 Literatures of Germanic languages");
                fourAnswers.Add("840 Literatures of Romance languages");
                mylist.Add("860 Spanish & Portuguese literatures");
                mylist.Add("870 Italic literatures, i.e., Latin");
                mylist.Add("880 Hellenic literatures, i.e., Classical Greek");
                mylist.Add("890 Literatures of other languages");



                shuffle();
                for (int i = 0; i < 3; i++)
                {
                    fourAnswers.Add(mylist[i]);
                }

                shufflefourAnswers();
                foreach (object item in fourAnswers)
                {
                    listbox2.Items.Add(item);
                }
            }
            if (answertb.Text == "840 Literatures of Romance languages" && descriptiontb.Text == "Old and early French to 1400850 Italian, Romanian, Rhaeto-Romanic")
            {
                MessageBox.Show("WOW! ALL MATCH, ALL CORRECT \n your answering is " + point + "% accurate");
            }

            if (answertb.Text != "800 Literature" && answertb.Text != "840 Literatures of Romance languages" && answertb.Text != "" && descriptiontb.Text == "Old and early French to 1400850 Italian, Romanian, Rhaeto-Romanic")
            {
                MessageBox.Show("oops, that doesn't seem right. try again.");
                point = point - 10;
            }



            //----------------------------10----------------------------------//
            if (answertb.Text == "900 History & Geography" && descriptiontb.Text == "Not assigned or no longer used")
            {
                MessageBox.Show("correct! do you know what sub-category it belongs in");

                mylist.Clear();
                fourAnswers.Clear();
                answertb.Text = "";

                mylist.Add("910 Geography & travel");
                mylist.Add("920 Biography, genealogy, insignias");
                mylist.Add("930 History of the ancient world");
                mylist.Add("940 General history of Europe");
                mylist.Add("950 General history of Asia & Far East");
                mylist.Add("960 General history of Africa");
                mylist.Add("970 General history of North America");
                mylist.Add("980 General history of South America");
                fourAnswers.Add("990 General history of other areas");


                shuffle();
                for (int i = 0; i < 3; i++)
                {
                    fourAnswers.Add(mylist[i]);
                }

                shufflefourAnswers();
                foreach (object item in fourAnswers)
                {
                    listbox2.Items.Add(item);
                }
            }
            if (answertb.Text == "990 General history of other areas" && descriptiontb.Text == "Not assigned or no longer used")
            {
                MessageBox.Show("WOW! ALL MATCH, ALL CORRECT \n your answering is " + point + "% accurate");
            }

            if (answertb.Text != "900 History & Geography" && answertb.Text != "990 General history of other areas" && answertb.Text != "" && descriptiontb.Text == "Not assigned or no longer used")
            {
                MessageBox.Show("oops, that doesn't seem right. try again.");
                point = point - 10;
            }
        }

        private void listbox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            answertb.Text = listbox2.SelectedItem.ToString(); //tp get the sub categpries/2nd level answers into the answer box
        }

        private void replaybtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Findcallnumbers FCN = new Findcallnumbers();
            FCN.Show();
        }

        private void homebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow MW = new MainWindow();   
            MW.Show();
        }
    }
}
