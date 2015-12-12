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
        public formCount()
        {
            InitializeComponent();
            textBoxNumbs.Text = "1 2 3 5 7 8 10 12 13 14";
        }

        private void buttonCount_Click(object sender, EventArgs e)
        {
            bool err = false;

            if (textBoxNumbs.Text.Length == 0)
            {
                labelError.Text = "Input arguments!!!";
                err = true;
            }

            if (!err)
            {
                labelError.Text = "";
                string numbs = textBoxNumbs.Text;

                List<Int32> Numbs = StringToList.Convert(numbs);

                QuineMc quineMc = new QuineMc(Numbs);
                quineMc.count();
                richTextBoxResult.Text = quineMc.Result();
            }
        }
    }
}
