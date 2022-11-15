using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planer
{
    public partial class ChekPointForm : Form
    {
        public ChekPointForm()
        {
            InitializeComponent();
        }

        public ChekPointForm(bool IsDeal):this()
        {
            monthCalendar1.Visible = IsDeal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
