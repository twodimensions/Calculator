using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Operations
    {
        //void OrderOfOP(string[] operation)
        //{
        //    operation[j] = 

        //}

        public void Add_numbers_into_one_array(double x, int y, int k) // x = value of input, y = size of total numbers, k = index of y
        {
            double[] total_numbers = new double[y];
            total_numbers[k]=x;
             
        }


        public double Add(double x, double y) // x = value of input, y = size of total numbers, k = index of y
        {
            double c;
            c = x + y;
            //c = x.Sum();
            return c;
        }

        
                     




        //public double Add(double x, int y, int k) // x = value of input, y = size of total numbers, k = index of y
        //{
        //    double[] total_numbers = new double[y];
        //    total_numbers[k] = x;

        //    if (total_numbers.Length == y) //or k ==y
        //    {


        //        double c;
        //        c = total_numbers.Sum();
        //        //c = x + y;
        //        return c;
        //    }
        //    return 0;

        //}


        public double TestFunction(double[] a)
        {
            return 0;
        }



        public double Subtract(double x, double y)
        {
            double c;
            c = x - y;
            return c;
        }

        public double Divide(double x, double y)
        {
            double c;
            c = x / y;
            if ( y == 0)
            {
                return -1; // DNE
            }
            return c;
        }

        public double Multiply(double x, double y)
        {
            double c;
            c = x * y;
            return c;
        }
        //public int Equals(int x, int y)
        //{
        //    return;
        //}
    }
}
