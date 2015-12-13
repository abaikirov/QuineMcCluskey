using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMapp
{
    class HelperClass
    {
        public static List<int> Convert(string str)
        {
            List<int> list = new List<int>();

            string[] strMass = str.Split(' ');

            foreach (string strElem in strMass)
            {
                int outResult;
                int.TryParse(strElem, out outResult);
                list.Add(outResult);
            }

            return list;
        }

        private static int Factorial(int a)
        {
            int factorial = 1;
            for (int i = 1; i <= a; i++)
                factorial *= i;
            return factorial;
        }

        private static int FactorialSpeed(int a , int b)
        {
            int factorial = 1;
            for (int i = a - b + 1; i <= a; i++)
                factorial *= i;
            return factorial;
        }

        public static int Combination(int n, int m)
        {
            int combination = FactorialSpeed(n,m) / Factorial(n - m);
            return combination;
        }

        
    }
}
