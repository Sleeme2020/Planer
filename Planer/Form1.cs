using Planer.AppContext;
namespace Planer
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            SingleTon.DB = new AppDb();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EventForm eventForm = new EventForm();
            if(eventForm.ShowDialog()==DialogResult.OK)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChekPointForm chekPointForm = new ChekPointForm();
            if(chekPointForm.ShowDialog()==DialogResult.OK)
            {

            }
        }
    }
}