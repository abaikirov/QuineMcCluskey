using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMapp
{
    class QuineMc
    {
        private List<int> list = new List<int>();
        private List<string> binaryList = new List<string>();
        private string result;

        public QuineMc(List<int> list)
        {
            this.list = list;
        }

        public List<int> getList()
        {
            return list;
        }

        public void count()
        {
            foreach (int listElem in list)
            {
                binaryList.Add(Convert.ToString(listElem, 2));
            }

            result = string.Join(",", binaryList);
        }

        public string Result()
        {
            return result;
        }
    }
}
