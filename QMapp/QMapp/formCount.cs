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
        }

        private void buttonCount_Click(object sender, EventArgs e)
        {
            string numbs = textBoxNumbs.Text;

            List<Int32> Numbs = StringToList.Convert(numbs);

            QuineMc quineMc = new QuineMc(Numbs);
            quineMc.count();
            richTextBoxResult.Text = quineMc.Result();
        }
    }
}
