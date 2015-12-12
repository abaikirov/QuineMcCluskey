using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QM
{
    public partial class countForm : Form
    {
        public countForm()
        {
            InitializeComponent();
        }

        private void buttonCount_Click(object sender, EventArgs e)
        {
            string numbs = textBoxNumbs.Text;

            List<Int32> Numbs = StringToList.Convert(numbs);

            QuineMc quineMc = new QuineMc(Numbs);
            quineMc.count();
            richTextBoxResult.Text = quineMc.Result;

        }
    }
}
