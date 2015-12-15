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
        private List<string> binaryListFilled = new List<string>();
        private List<string> kpiCube = new List<string>();
        private List<string> implicaty = new List<string>();
        private Dictionary<string, List<string>> minTable = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> maxTable = new Dictionary<string, List<string>>();
        private List<string> yeff = new List<string>();
        private List<string> Y = new List<string>();
        private string result = "";

        public void Del()
        {
            list.Clear();
            binaryList.Clear();
            binaryListFilled.Clear();
            kpiCube.Clear();
            implicaty.Clear();
            minTable.Clear();
            maxTable.Clear();
            yeff.Clear();
            Y.Clear();
            result = "";
        }

        private void ResultForming()
        {
            result = "In arguments: ";
            result += string.Join(",", list) + "\n";
            result += "Binary presentation: ";
            result += string.Join(",", binaryList) + "\n";
            result += "KPI cube: ";
            result += string.Join(",", kpiCube) + "\n";
            if (maxTable.Count != 0)
            {
                result += "Table:\n";
                foreach (var pair in maxTable)
                    result += pair.Key + "{" + string.Join(",", pair.Value) + "}" + "\n";
            }
            result += "Implicaty sushestvennye: ";
            result += string.Join(",", implicaty) + "\n";
            if (!minTable.Keys.Contains("table"))
                if (minTable.Count != 0)
                {
                    result += "Minimal table:\n";
                    foreach (var pair in minTable)
                        result += pair.Key + "{" + string.Join(",", pair.Value) + "}" + "\n";
                }
            if (yeff.Count != 0)result += "Y effectivly: " + string.Join(",", yeff) + "\n";
            result += "Minimal function : ";
            foreach(var func in Y)
            {
                result += "(";
                for(int lit = 0;lit < func.Length; lit++)
                {
                    if (func[lit] == 'X') continue;
                    if (func[lit] == '\u0031') result += "X" + Convert.ToString(lit + 1) + " * ";
                    else result += "!X" + Convert.ToString(lit + 1) + " * ";
                }
                result += ") + ";
            }

        }

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

        public List<string> GetImplicaty()
        {
            return implicaty;
        }

        public Dictionary<string, List<string>> GetMinTable()
        {
            return minTable;
        }

        public Dictionary<string, List<string>> GetMaxTable()
        {
            return maxTable;
        }

        public List<string> GetBinaryListFilled()
        {
            return binaryListFilled;
        }

        public List<string> GetYeff()
        {
            return yeff;
        }

        public List<string> GetMinFunc()
        {
            return Y;
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

        private List<List<int>> CombinationList(int n, int m)
        {
            List<List<int>> combinationList = new List<List<int>>();

            int end = (int)System.Math.Pow((double)2, (double)n) - 1;
            List<int> decNumbs = new List<int>();
            for (int x = 1; x < end; x++)
            {
                decNumbs.Add(x);
            }
            List<string> binaryListFilled = FillZero(ToBinary(decNumbs));
            for (int binary = 0; binary < binaryListFilled.Count; binary++)
            {
                List<int> BinaryX = new List<int>();
                for (int character = 0; character < binaryListFilled[binary].Length; character++)
                {
                    if (binaryListFilled[binary][character] == '\u0031')
                        BinaryX.Add(character);
                }
                if (BinaryX.Count == m)
                    combinationList.Add(BinaryX);
            }
            return combinationList;
        }

        private int XCount(string numb)
        {
            int xCount = 0;

            foreach (var X in numb)
                if (X == 'X') xCount++;

            return xCount;
        }

        //Формирование 1-кубов
        private List<List<string>> OneCubeGroups(List<string> listString)
        {
            List<List<string>> oneCubeGroups = new List<List<string>>();

            int countX = XCount(listString[0]);
            int combination = HelperClass.Combination(listString[0].Length, countX);
            List<List<int>> comboXindexs = CombinationList(listString[0].Length, countX);

            List<string> oneCube = new List<string>();
            foreach (string listItem in listString)
            {
                List<int> Xindexs = new List<int>();
                for (int Xindex = 0; Xindex < listItem.Length; Xindex++)
                    if (listItem[Xindex] == '\u0058')
                        Xindexs.Add(Xindex);
                foreach (var comboXindex in comboXindexs)
                    if (Xindexs.All(comboXindex.Contains))
                    {
                        oneCube.Add(listItem);
                    }
            }
            
            oneCubeGroups.Add(oneCube);
            

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
                if (!kpiCube.Contains(key.Key))
                    kpiCube.Add(key.Key);
            }
        }

        //Функция проверки на окончание формирования новых кубов
        private bool LoopChecker(Dictionary<string, int> dict)
        {
            bool checker = true;

            var values = dict.Values.ToArray();

            foreach (var value in values)
            {
                if (value != 0) checker = true;
                else checker = false;
            }
            return checker;
        }

        //Формирование таблицы
        private Dictionary<string, List<string>> MaxTable(List<string> implicaty, List<string> numbs)
        {
            Dictionary<string, List<string>> maxTable = new Dictionary<string, List<string>>();

            foreach (var impli in implicaty)
            {
                List<string> impliValues = new List<string>();
                foreach (var numb in numbs)
                {
                    string currNumb = "";
                    bool err = false;
                    for (int character = 0; character < impli.Length; character++)
                    {
                        if (impli[character] == '\u0058') continue;
                        if (impli[character] == numb[character]) currNumb = numb;
                        else
                        {
                            currNumb = "";
                            err = true;
                            break;
                        }
                    }
                    if (err) continue;
                    else
                    {
                        impliValues.Add(currNumb);
                    }
                }
                maxTable.Add(impli, impliValues);
            }

            return maxTable;
        }

        //Формирование мин таблицы
        private Dictionary<string,List<string>> MinTable (Dictionary<string, List<string>> maxTable , List<string> numbs)
        {
            Dictionary<string, List<string>> minTable = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> inTable = new Dictionary<string, List<string>>();
            List<string> Numbs = numbs;

            foreach (var numb in Numbs)
            {
                List<string> Xnumbs = new List<string>();
                foreach (var line in maxTable)
                {
                    if (line.Value.Contains(numb)) Xnumbs.Add(line.Key);
                }
                inTable.Add(numb, Xnumbs);
            }

            foreach(var pair in inTable)
            {
                if (pair.Value.Count == 1)
                {
                    if (!implicaty.Contains(pair.Value.First())) implicaty.Add(pair.Value.First());
                    Numbs.Remove(pair.Key);
                }
            }

            foreach (var impli in implicaty)
                foreach (var delElem in maxTable[impli])
                    if (Numbs.Contains(delElem)) Numbs.Remove(delElem);

            if (Numbs.Count != 0)
            {
                foreach (var pair in inTable)
                    foreach (var num in Numbs)
                        if (pair.Key == num)
                        {
                            List<string> val = new List<string>();
                            val.Add(pair.Key);
                            foreach (var key in pair.Value)
                            {
                                if (!minTable.Keys.Contains(key)) minTable.Add(key, val);
                                else minTable[key].Add(pair.Key);
                            }
                        }
            }
            else { var list = new List<string> { "0", "1" }; minTable.Add("table", list); }
            

            return minTable;
        }

        //Функция рассчета Y эффективного
        private List<string> YeffConst (Dictionary<string, List<string>> minTable)
        {
            List<string> yeffConst = new List<string>();
            Dictionary<string, List<string>> minTableInvers = new Dictionary<string, List<string>>();

            foreach(var pair in minTable)
            {
                List<string> pairList = new List<string> { pair.Key };
                foreach (var val in pair.Value)
                {
                    if (!minTableInvers.Keys.Contains(val)) minTableInvers.Add(val, pairList);
                    else minTableInvers[val].Add(pair.Key);
                }
                
            }

            foreach (var pair in minTableInvers)
            {
                string minZeroStr = pair.Value[0];
                int minZero = pair.Value[0].Where(x => x == '\u0030').Count();
                foreach (var val in pair.Value)
                    if (minZero > val.Where(x => x == '\u0030').Count()) { minZero = val.Where(x => x == '\u0030').Count(); minZeroStr = val; }
                yeffConst.Add(minZeroStr);
            }
            return yeffConst;
        }

        private List<string> MinFunc (List<string> impli, List<string> yeff)
        {
            List<string> minFunc = new List<string>();

            foreach (var implicat in impli)
                minFunc.Add(implicat);
            foreach (var y in yeff)
                minFunc.Add(y);

            return minFunc;
        }

        //Функция счета
        public void count()
        {
            binaryList = ToBinary(list);
            binaryListFilled = FillZero(binaryList);
            Dictionary<string, int> dictBinaryZeroCube = ToDict(binaryListFilled);
            List<List<string>> zeroCubeGroups = ZeroCubes(binaryListFilled);
            List<string> oneCube = OneCube(zeroCubeGroups, dictBinaryZeroCube);
            if (oneCube.Count != 0)
            {
                KPICheker(dictBinaryZeroCube);

                List<List<string>> oneCubeGroups = OneCubeGroups(oneCube);
                Dictionary<string, int> dictBinaryOneCube = ToDict(oneCube);
                List<string> twoCube = TwoCube(oneCubeGroups, dictBinaryOneCube);
                KPICheker(dictBinaryOneCube);

                var loopTwoCube = twoCube;
                bool x_endless = true;
                if (loopTwoCube.Count != 0)
                {
                    while (x_endless)
                    {
                        var loopCube = OneCubeGroups(loopTwoCube);
                        var dictLoopCube = ToDict(loopTwoCube);
                        loopTwoCube = TwoCube(loopCube, dictLoopCube);
                        KPICheker(dictLoopCube);
                        x_endless = LoopChecker(dictLoopCube);
                    }
                }
            }
            maxTable = MaxTable(kpiCube, binaryListFilled);
            minTable = MinTable(maxTable, binaryListFilled);
            if (!minTable.Keys.Contains("table"))yeff = YeffConst(minTable);
            Y = MinFunc(implicaty, yeff);
            ResultForming();
        }
    }
}
