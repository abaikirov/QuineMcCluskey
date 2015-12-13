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

        public static List<List<int>> CombinationList(int n, int m)
        {
            List<List<int>> combinationList = new List<List<int>>();
            List<List<int>> combinationList2 = new List<List<int>>();

            
                
            List<int> comboItem2 = new List<int>();

            for (int toComboEnd = n - m, toComboStart = 0; toComboStart < n - toComboEnd; toComboStart++)
            {
                for (int X = toComboStart; X < toComboEnd; X++)
                {
                    comboItem2.Add(X);
                }
            }

            //for (int tocombo = 0; tocombo < n - 3; tocombo++)
            //    for(int tocombo2 = tocombo + 1; tocombo2 < n - 2; tocombo2++)
            //        for(int tocombo3 = tocombo2 + 1; tocombo3 < n - 1; tocombo3++)
            //            for(int tocombo4 = tocombo3 + 1; tocombo4 < n; tocombo4++)

            combinationList2.Add(comboItem2);
           

            for (int len = 0; len < combinationList2[0].Count; len++)
            {
                List<int> comboItem = new List<int>();
                foreach (List<int> comboItemIn in combinationList2)
                    comboItem.Add(comboItemIn[len]);
                combinationList.Add(comboItem);
            }

            return combinationList;
        }
    }
}
