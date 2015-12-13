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
        private List<string> kpiCube = new List<string>();
        private string result;
        public string Result()
        {
            return result;
        }

        public QuineMc()
        {
            
        }

        public void SetList(List<int> list)
        {
            this.list = list;
        }

        public List<int> GetList()
        {
            return list;
        }

        public List<string> GetKPI()
        {
            return kpiCube;
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

        //Замена на Х
        private string ChangeToX(string binary1, string binary2)
        {
            string binaryX = "";
            int sameCount = 0;
            for (int liter = 0; liter < binary1.Length; liter++)
            {
                if (binary1[liter] == binary2[liter])
                    binaryX += binary1[liter];
                else
                {
                    binaryX += "X";
                    sameCount++;
                }
            }
            if (sameCount != 1)
            {
                binaryX = "";
            }

            return binaryX;
        }

        //Формирование 1-куба
        private List<string> OneCube(List<List<string>> listOfLists, Dictionary<string,int> dict)
        {
            List<string> oneCube = new List<string>();

            for (int i = 0; i < listOfLists.Count - 1; i++)
                for(int j = i + 1; j < listOfLists.Count; j++)
                {
                    foreach (string listItem_i in listOfLists[i])
                        foreach(string listItem_j in listOfLists[j])
                        {
                            string newNumb = ChangeToX(listItem_i, listItem_j);
                            if (newNumb != "")
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

            int countX = listString[0].Where(x => x == '\u0058').Count();
            int combination = HelperClass.Combination(listString[0].Length, countX);
            List<List<int>> comboXindexs = HelperClass.CombinationList(listString[0].Length, countX);

            foreach (var comboXindex in comboXindexs)
            {
                List<string> oneCube = new List<string>();
                foreach (string listItem in listString)
                {
                    List<int> Xindexs = new List<int>();
                    for (int Xindex = 0; Xindex < listItem.Length; Xindex++)
                        if (listItem[Xindex] == 'X')
                            Xindexs.Add(Xindex);

                    if (Xindexs == comboXindex)
                    {
                        oneCube.Add(listItem);
                    }
                }
                oneCubeGroups.Add(oneCube);
            }

            return oneCubeGroups;
        }

        //Формирование 2-куба
        private List<string> TwoCube(List<List<string>> listOfLists, Dictionary<string, int> dict)
        {
            List<string> twoCube = new List<string>();

            foreach (List<string> list in listOfLists)
            {
                for(int i = 0; i < list.Count - 1; i++)
                    for(int j = i + 1; j < list.Count; j++)
                    {
                        string newNumb = ChangeToX(list[i], list[j]);
                        if (newNumb != "")
                        {
                            if (!twoCube.Contains(newNumb))
                                twoCube.Add(newNumb);
                            dict[list[i]] += 1;
                            dict[list[j]] += 1;
                        }
                    }
            }

            return twoCube;
        }

        //Функция заполнения КПИ

        private void KPICheker(Dictionary<string,int> dict)
        {
            var keys =  from dicts in dict
                        where dicts.Value == 0
                        select dicts;
            foreach (KeyValuePair<string,int> key in keys)
            {
                kpiCube.Add(key.Key);
            }

            

        }

        //Функция счета
        public void count()
        {
            binaryList = ToBinary(list);
            List<string> binaryListFilled = FillZero(binaryList);
            Dictionary<string, int> dictBinaryZeroCube = ToDict(binaryListFilled);
            List<List<string>> zeroCubeGroups = ZeroCubes(binaryListFilled);
            List<string> oneCube = OneCube(zeroCubeGroups, dictBinaryZeroCube);
            KPICheker(dictBinaryZeroCube);


            List<List<string>> oneCubeGroups = OneCubeGroups(oneCube);
            Dictionary<string, int> dictBinaryOneCube = ToDict(oneCube);
            List<string> twoCube = TwoCube(oneCubeGroups, dictBinaryOneCube);
            KPICheker(dictBinaryOneCube);



            var loopTwoCube = twoCube;
            bool x_endless = false;
            while (x_endless)
            {
                var loopCube = OneCubeGroups(loopTwoCube);
                var dictLoopCube = ToDict(loopTwoCube);
                loopTwoCube = TwoCube(loopCube, dictLoopCube);
                KPICheker(dictLoopCube);

            }


        }

        
    }
}
