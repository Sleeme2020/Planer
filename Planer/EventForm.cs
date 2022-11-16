using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Planer.Model;

namespace Planer
{
    public partial class EventForm : Form
    {
        public EventForm()
        {
            InitializeComponent();
            
        }
        public EventForm(People[] peoples):this()
        {
            comboBox1.Items.AddRange(peoples);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            

            switch((sender as RadioButton)?.Name)
            {
                case "DealTask":
                    panel1.Visible = true;
                    panel2.Visible = false;
                    break;

                case "EventTask":
                    panel1.Visible = false;
                    panel2.Visible = true;
                    break;

                    default:
                    panel1.Visible = false;
                    panel2.Visible = false;
                    break;

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
