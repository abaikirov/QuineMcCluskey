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
        public string Result()
        {
            return result;
        }

        public QuineMc(List<int> list)
        {
            this.list = list;
            binaryList = ToBinary(list);
        }

        public List<int> getList()
        {
            return list;
        }

        //Перевод из десятичной системы в двоичную
        private List<string> ToBinary(List<int> listInt)
        {
            List<string> listString = new List<string>();
            foreach (int listElem in listInt)
            {
                listString.Add(Convert.ToString(listElem, 2));
            }
            return listString;
        }

        //Нахождение максимального двоичного кода
        private int MaxLength(List<string> listString)
        {
            int maxLength = listString[0].Length;
            foreach (string listItem in listString)
            {
                if (maxLength < listItem.Length)
                {
                    maxLength = listItem.Length;
                }
            }
            return maxLength;
        }

        //Выравнивание двоичных кодов по длине
        private List<string> FillZero(List<string> listString)
        {
            List<string> listStringZero = new List<string>();

            int maxLength = MaxLength(listString);
            foreach (string listItem in listString)
            {
                string filled = listItem;
                for (int i = 0; i < ( maxLength - listItem.Length ) ; i++)
                {
                    filled = "0" + filled;
                }
                listStringZero.Add(filled);
            }

            return listStringZero;
        }

        //Создание словаря, где ключом является число, а значением - сколько раз его использовали
        private Dictionary<string,int> ToDict(List<string> listString)
        {
            Dictionary<string, int> dictBinary = new Dictionary<string, int>();

            foreach (string listItem in listString)
            {
                dictBinary.Add(listItem, 0);
            }

            return dictBinary;
        }

        //Формирование 0-кубов
        private List<List<string>> ZeroCubes(List<string> listString)
        {
            List<List<string>> zeroCube = new List<List<string>>();

            for (int i = listString[0].Length; i >= 0; i--)
            {
                List<string> cube = new List<string>();
                int zeroCount = 0;
                foreach (string listItem in listString)
                {
                    zeroCount = listItem.Where(x => x == '\u0030').Count();

                    if (zeroCount == i)
                    {
                        cube.Add(listItem);
                    }
                }
                if (cube.Count != 0)
                {
                    zeroCube.Add(cube);
                }
            }

            return zeroCube;
        }

        //Формирование 1-куба
        private List<string> OneCube(List<List<string>> listOfLists, Dictionary<string,int> dict)
        {
            List<string> oneCube = new List<string>();

            for (int i = 0; i < listOfLists.Count - 1; i++)
                for(int j = 1; j < listOfLists.Count; j++)
                {
                    foreach (string listItem_i in listOfLists[i])
                        foreach(string listItem_j in listOfLists[j])
                        {
                            string newNumb = "";
                            int sameCount = 0;
                            for (int liter = 0; liter < listItem_i.Length; liter++)
                            {
                                if (listItem_i[liter] == listItem_j[liter])
                                    newNumb += listItem_i[liter];
                                else
                                {
                                    newNumb += "X";
                                    sameCount++;
                                }
                            }
                            if (sameCount == 1)
                            {
                                oneCube.Add(newNumb);
                                dict[listItem_i] += 1;
                                dict[listItem_j] += 1;
                            }
                        }
                }

            return oneCube;
        }

        //Формирование 1-кубов
        private List<List<string>> OneCubeGroups(List<string> listString)
        {
            List<List<string>> oneCubeGroups = new List<List<string>>();

            for(int i = 0; i < listString[0].Length; i++)
            {
                List<string> oneCube = new List<string>();
                foreach (string listItem in listString)
                {
                    if (listItem[i] == 'X')
                    {
                        oneCube.Add(listItem);
                    }
                }
                oneCubeGroups.Add(oneCube);
            }

            return oneCubeGroups;
        }

        //Функция счета
        public void count()
        {
            List<string> binaryListFilled = FillZero(binaryList);
            Dictionary<string, int> dictBinary = ToDict(binaryListFilled);
            List<List<string>> zeroCubeGroups = ZeroCubes(binaryListFilled);
            List<string> oneCube = OneCube(zeroCubeGroups, dictBinary);
            List<List<string>> oneCubeGroups = OneCubeGroups(oneCube);
            foreach (List<string> a in oneCubeGroups)
            {
                result += string.Join(",", a) + "\n";
            }

        }

        
    }
}
