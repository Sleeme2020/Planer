using Microsoft.EntityFrameworkCore;
using Planer.AppContext;
using Planer.Model;

namespace Planer
{
   
    public partial class Form1 : Form
    {  
        public Form1()
        {          
            InitializeComponent();
            SingleTon.DB = new AppDb();
            updatePanel();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SingleTon.DB.Peoples.Load();
            EventForm eventForm = new EventForm(SingleTon.DB.Peoples.Local.ToArray());
            
            if(eventForm.ShowDialog()==DialogResult.OK)
            {
                AbstractTask abstractTask;
                if ((eventForm.groupBox1.Controls["DealTask"] as RadioButton)?.Checked == true)
                {
                    abstractTask = new DealTask() { Name = eventForm.textBox1.Text,
                        People = (eventForm.comboBox1.SelectedItem as People), 
                        Start = eventForm.monthCalendar1.SelectionStart, 
                        End = eventForm.monthCalendar1.SelectionEnd };
                    SingleTon.DB.Add(abstractTask);
                }
                if((eventForm.groupBox1.Controls["EventTask"] as RadioButton)?.Checked==true)
                {
                    abstractTask = new EventTask() {
                        Name = eventForm.textBox1.Text,
                        People = (eventForm.comboBox1.SelectedItem as People),
                        Date = eventForm.dateTimePicker1.Value,
                        Location = eventForm.textBox2.Text
                    };
                    SingleTon.DB.Add(abstractTask);
                }

                SingleTon.DB.SaveChanges();
                
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChekPointForm chekPointForm = new ChekPointForm();
            if(chekPointForm.ShowDialog()==DialogResult.OK)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PeopleForm peopleform = new PeopleForm();

            if (peopleform.ShowDialog() == DialogResult.OK)
            {
                People people = new People()
                {
                    Name = peopleform.textBox1.Text,
                    FirstName = peopleform.textBox2.Text
                };
                SingleTon.DB.Add(people);
                SingleTon.DB.SaveChanges();
            }
        }



        void updatePanel()
        {
            Func<AbstractTask, bool> fuctionload = (u) => {
            if(u is EventTask)
                {
                    if ((u as EventTask).Date > monthCalendar1.SelectionStart && (u as EventTask).Date < monthCalendar1.SelectionEnd)
                        return true;
                    else
                        return false;
                }
            if(u is DealTask)
                {
                    if ((u as DealTask).Start >= monthCalendar1.SelectionStart && (u as DealTask).End <= monthCalendar1.SelectionEnd)
                        return true;
                    else
                        return false;
                }
            return false;           
            
            };            
            var tasks = SingleTon.DB.Tasks.Where(u=> fuctionload(u));
            foreach (var task in tasks)
            {
                //ListViewItem item = new ListViewItem();
                //item.SubItems.Add(task.ToString());
                listView1.Items.Add(task.ToString());
            }
        }





    }
}