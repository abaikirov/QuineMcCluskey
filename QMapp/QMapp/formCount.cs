using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QMapp
{
    public partial class formCount : Form
    {

        QuineMc quineMc = new QuineMc();

        

        public formCount()
        {
            InitializeComponent();
            textBoxNumbs.Text = "1 2 5 7 9 10 14 15";
        }

        private void buttonCount_Click(object sender, EventArgs e)
        {

            quineMc.Del();
            bool err = false;

            labelBtnErrorLeft.Text = "";
            labelBtnErrorUp.Text = "";

            if (textBoxNumbs.Text.Length == 0)
            {
                labelError.Text = "Input arguments!!!";
                err = true;
            }

            if (!err)
            {
                labelError.Text = "";
                string numbs = textBoxNumbs.Text;

                List<Int32> Numbs = HelperClass.Convert(numbs);
                quineMc.SetList(Numbs);
                
                quineMc.count();
                richTextBoxResult.Text = quineMc.Result();
                
            }
        }

        private void buttonKPI_Click(object sender, EventArgs e)
        {
            richTextBoxResult.Text = "";
            var kpi = quineMc.GetKPI();
            if (kpi.Count != 0)
                richTextBoxResult.Text = string.Join(",", kpi) + "\n";
            else
            {
                labelBtnErrorLeft.Text = "!!!Press this button ->";
                labelBtnErrorUp.Text = "!!!Press this button\n            |\n           \\/";
            }
        }

        private void buttonYMin_Click(object sender, EventArgs e)
        {
            richTextBoxResult.Text = "";
            var Y = quineMc.GetMinFunc();
            if (Y.Count != 0)
                foreach (var func in Y)
                {
                    richTextBoxResult.Text += "(";
                    for (int lit = 0; lit < func.Length; lit++)
                    {
                        if (func[lit] == 'X') continue;
                        if (func[lit] == '\u0031') richTextBoxResult.Text += "X" + Convert.ToString(lit + 1) + " + ";
                        else richTextBoxResult.Text += "!X" + Convert.ToString(lit + 1) + " + ";
                    }
                    richTextBoxResult.Text += ") * ";
                }
            else
            {
                labelBtnErrorLeft.Text = "!!!Press this button ->";
                labelBtnErrorUp.Text = "!!!Press this button\n            |\n           \\/";
            }
        }

        private void buttonMinTable_Click(object sender, EventArgs e)
        {
            richTextBoxResult.Text = "";
            var minTable = quineMc.GetMinTable();
            var minTableNumbs = quineMc.GetMinTableNumbs();
            if (minTable.Count != 0)
            {

                if (!minTable.Keys.Contains("table"))
                {
                    richTextBoxResult.Text = "\t";
                    foreach (var num in minTableNumbs)
                        richTextBoxResult.Text += "|" + num + "\t|";
                    richTextBoxResult.Text += "\n";
                    foreach (var pair in minTable)
                    {
                        richTextBoxResult.Text += pair.Key + "\t";
                        foreach (var num in minTableNumbs)
                        {
                            if (pair.Value.Contains(num)) richTextBoxResult.Text += "|ok\t|";
                            else richTextBoxResult.Text += "|\t|";
                        }
                        richTextBoxResult.Text += "\n";
                    }
                }


                else richTextBoxResult.Text += "No minTable";
            }
            else
            {
                labelBtnErrorLeft.Text = "!!!Press this button ->";
                labelBtnErrorUp.Text = "!!!Press this button\n            |\n           \\/";
            }
        }

        private void buttonImplicaty_Click(object sender, EventArgs e)
        {
            richTextBoxResult.Text = "";
            var implicaty = quineMc.GetImplicaty();
            if (implicaty.Count != 0)
                richTextBoxResult.Text = string.Join(",", implicaty) + "\n";
            else
            {
                labelBtnErrorLeft.Text = "!!!Press this button ->";
                labelBtnErrorUp.Text = "!!!Press this button\n            |\n           \\/";
            }
        }

        private void buttonMaxTable_Click(object sender, EventArgs e)
        {
            richTextBoxResult.Text = "";
            var maxTable = quineMc.GetMaxTable();
            var TableNumbs = quineMc.GetBinaryListFilled();
            if (maxTable.Count != 0)
            {
                richTextBoxResult.Text = "\t";
                foreach (var num in TableNumbs)
                    richTextBoxResult.Text += "|" + num + "\t|";
                richTextBoxResult.Text += "\n";
                foreach (var pair in maxTable)
                {
                    richTextBoxResult.Text += pair.Key + "\t";
                    foreach (var num in TableNumbs)
                    {
                        if (pair.Value.Contains(num)) richTextBoxResult.Text += "|ok\t|";
                        else richTextBoxResult.Text += "|\t|";
                    }
                    richTextBoxResult.Text += "\n";
                }
            }
            else
            {
                labelBtnErrorLeft.Text = "!!!Press this button ->";
                labelBtnErrorUp.Text = "!!!Press this button\n            |\n           \\/";
            }
        }
    }
}
