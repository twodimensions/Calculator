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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        double[] Array1 = new double[15];
        string[] operations = new string[15];
        public int j = 0;
        int globalequal = 0;
        int AddToPastSum = 0;
        //double[] Array2 = new double[15];
        public MainWindow()
        {
            InitializeComponent();

            var Input = new Operations();

            
        }


        private void UpdateCalc1(string i)
        {

            if ( i == "/" || i == "+" || i == "-" || i == "X" || i == "=")
            {
                j++; // counter how manytimes operation symbol hit
                //operations[j-1] = i;
                Console.WriteLine("J = " + j);
                Console.WriteLine(Text2.Text);
                for(int k =0; k < 3;k++)
                {
                    Console.WriteLine("Before change op = " + operations[k]);
                }
                

                if ( Text2.Text != "" )
                {
                    Text1.Text += " " + Text2.Text + " " +i;
                    Text2.Text = null;
                }
                else
                {
                    j--; // when a blank is entered go back to previous counter
                }

                if (Text1.Text.EndsWith("/") || Text1.Text.EndsWith("+") || Text1.Text.EndsWith("-") || Text1.Text.EndsWith("*"))
                {
                    Text1.Text = Text1.Text.Remove(Text1.Text.Length - 1) + i;
                    operations[j - 1] = i;
                }




            }
            else
            {
                Text2.Text += i;
                Array1[j] = double.Parse(Text2.Text);
                //Console.WriteLine(Array1[j] + "  j = " + j);
                //Console.WriteLine(Array1[0] + "  j = 0");
            }

        }

        private void SetCal(string x)
        {

            if (globalequal == 0)
            {
                UpdateCalc1(x);
            }
            else
            {
                Console.WriteLine("AddToPastSum = " + AddToPastSum);
                Console.WriteLine("globalequal = " + globalequal);


                if (AddToPastSum == 1)
                {
                    UpdateCalc1(x);
                }
                else
                {
                    globalequal = 0;
                    Text2.Text = "";
                    j = 0;
                    Array.Clear(Array1, 0, Array1.Length); // clear array.
                    UpdateCalc1(x);
                }

            }


        } // sets the calcualtor


        private void One_Click(object sender, RoutedEventArgs e) // input 1
        {

            SetCal("1");





            //if (globalequal == 0)
            //{
            //    UpdateCalc1("1");
            //}
            //else
            //{
            //    Console.WriteLine("AddToPastSum = " + AddToPastSum);
            //    Console.WriteLine("globalequal = " + globalequal);


            //    if (AddToPastSum == 1)
            //    {
            //        UpdateCalc1("1");
            //    }
            //    else
            //    {
            //        globalequal = 0;
            //        Text2.Text = "";
            //        j = 0;
            //        Array.Clear(Array1, 0, Array1.Length); // clear array.
            //        UpdateCalc1("1");
            //    }

            //}
        
        }

        private void Two_Click(object sender, RoutedEventArgs e) //input 2
        {
            SetCal("2");
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {

            var Input = new Operations();
            string Test = Text1.Text + " "+ Text2.Text;

            Text1.Text = "";
            //double total = Array1[0];
            double[] totalA = new double[15];
            double[] total2 = new double[15];


            List<int> whereOpisM = new List<int>();
            List<int> whereOpisD = new List<int>();
            List<int> whereOpisS = new List<int>();
            List<int> whereOpisA = new List<int>();



            for (int i = 0; i < operations.Length; i++)
            {

                if (operations[i] == "X")
                { whereOpisM.Add(i); }
                if (operations[i] == "/")
                { whereOpisD.Add(i); }
                if (operations[i] == "+")
                { whereOpisA.Add(i); }
                if (operations[i] == "-")
                { whereOpisS.Add(i); }
            }

            if (whereOpisM.Count != 0)
            {
                for (int j = 0; j < whereOpisM.Count; j++)
                {
                    total2[j] = Input.Multiply(Array1[whereOpisM[j]], Array1[whereOpisM[j + 1]]);
                }

            }
            if (whereOpisA.Count != 0)
            {
                for (int k = 0; k < whereOpisA.Count; k++)
                {
                    if (whereOpisM.Count != 0)
                    {
                        totalA[k] = Input.Add(total2[k], total2[k + 1]);
                    }
                    else
                    {
                        totalA[k] = Input.Add(totalA[k], Array1[k + 1]);
                    }
                }

            }

            //    for (int i=0; i<operations.Length;i++)
            //{


            //    if (operations[i] == "X")
            //    {
            //        total = Input.Multiply(total, Array1[i + 1]);
            //    }
            //    if (operations[i] == "-")
            //    {
            //        total = Input.Subtract(total, Array1[i + 1]);

            //    }
            //    if(operations[i] == "+")
            //    {

            //        total = Input.Add(total, Array1[i + 1]);
            //    }

            //}
            Text2.Text = Convert.ToString(totalA.Sum());

            //reset globals
            globalequal = 1;
            AddToPastSum = 0;

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (globalequal == 1)
            {
                AddToPastSum = 1;
                UpdateCalc1("+");
            }
            else
            {
                UpdateCalc1("+");
            }
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            globalequal = 0;
            Text2.Text = "";
            Text1.Text = "";
            j = 0;
            Array.Clear(Array1, 0, Array1.Length); // clear array.
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            Array.Clear(Array1, j, j); // clear array.
            Text2.Text = "";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (globalequal != 1)
            {
                if (Text2.Text != string.Empty)
                {
                    int txtlength = Text2.Text.Length;
                    if(txtlength !=1)
                    {
                        Text2.Text = Text2.Text.Remove(txtlength - 1);
                    }
                    else
                    {
                        Text2.Text = 0.ToString();
                    }
                Array1[j] = double.Parse(Text2.Text);
                Console.WriteLine("Array[j] = " + Array1[j]);
                }
            }
        }

        private void Subtract_Click(object sender, RoutedEventArgs e)
        {
            if (globalequal == 1)
            {
                AddToPastSum = 1;
                UpdateCalc1("-");
            }
            else
            {
                UpdateCalc1("-");
            }
        }

        private void Three_Click(object sender, RoutedEventArgs e) //input 3
        {
            SetCal("3");
        }

        private void Zero_Click(object sender, RoutedEventArgs e) //input 0
        {
            SetCal("0");
        }

        private void Four_Click(object sender, RoutedEventArgs e) //input 4
        {
            SetCal("4");
        }

        private void Five_Click(object sender, RoutedEventArgs e) //input 5
        {
            SetCal("5");
        }

        private void Six_Click(object sender, RoutedEventArgs e) //input 6
        {
            SetCal("6");
        }

        private void Nine_Click(object sender, RoutedEventArgs e) //input 9
        {
            SetCal("9");
        }

        private void Eight_Click(object sender, RoutedEventArgs e) //input 8
        {
            SetCal("8");
        }

        private void Seven_Click(object sender, RoutedEventArgs e) //input 7
        {
            SetCal("7");
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            if (globalequal == 1)
            {
                AddToPastSum = 1;
                UpdateCalc1("X");
            }
            else
            {
                UpdateCalc1("X");
            }
        }
    }
}
