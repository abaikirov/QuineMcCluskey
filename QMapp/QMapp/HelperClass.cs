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
            int combination = FactorialSpeed(n,m) / Factorial(m);
            return combination;
        }

        public static List<List<int>> CombinationList(int n, int m)
        {
            List<List<int>> combinationList = new List<List<int>>();

            int combination = Combination(n, m);

            for (int i = 0; i < combination; i++)
            {
                List<int> comboItem = new List<int>();

                for (int toCombo = 0; toCombo < n - 3; toCombo++)
                    for(int toCombo2 = toCombo + 1; toCombo2 - 2 < n; toCombo2++)
                        for(int toCombo3 = toCombo2 + 1; toCombo3 - 1 < n; toCombo3++)
                            for(int toCombo4 = toCombo3 + 1; toCombo4 < n; toCombo4++)

                combinationList.Add(comboItem);
            }

            return combinationList;
        }
    }
}
