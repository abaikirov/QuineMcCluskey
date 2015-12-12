using System;
using System.Collections.Generic;
using System.Text;

namespace QM
{
    class StringToList
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
    }
}
