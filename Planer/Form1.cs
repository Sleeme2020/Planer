using Microsoft.EntityFrameworkCore;
using Planer.AppContext;
using Planer.Model;
using System.Linq;

namespace Planer
{
   
    public partial class Form1 : Form
    {  
        public Form1()
        {          
            InitializeComponent();
            //SingleTon.DB = new AppDb();
            updatePanel(null,null);

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
                updatePanel(null, null);
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



        void updatePanel(object sender, DateRangeEventArgs e)
        {
            clearList();
            var tasks = SingleTon.DB.Tasks
                .Where(u => ((u as DealTask).Start >= monthCalendar1.SelectionStart && (u as DealTask).End <= monthCalendar1.SelectionEnd) 
                || ((u as EventTask).Date > monthCalendar1.SelectionStart && (u as EventTask).Date < monthCalendar1.SelectionEnd));
            //foreach (var task in tasks)
            //{
            //  ListViewItem item = new ListViewItem();
            //    item.SubItems.Add(task.ToString());
            //   listView1.Items.Add(item);
            //}
            BuildListViewPlaner(tasks);
        }
        void clearList()
        {
            
        }

        public void BuildListViewPlaner( IQueryable<AbstractTask>? queryable)
        {

            var colect = queryable.Select(u =>
            new { Id = u.Id,
                Name = u.ToString(),
                Date = (u as DealTask).Start == null ? (u as EventTask).Date: (u as DealTask).Start
            }).GroupBy(u=>u.Date);
            foreach(var item in colect)
            {
                foreach(var task in item)
                {

                }



                //DateTime date = (item as DealTask)?.Start ?? (item as EventTask).Date;
                //switch( date.DayOfWeek)
                //{
                //    case DayOfWeek.Monday:
                //        listBox1.Items.Add(item);
                //        break;
                //    case DayOfWeek.Tuesday:
                //        listBox2.Items.Add(item);
                //        break;

                //    case DayOfWeek.Wednesday:
                //        listBox3.Items.Add(item);
                //        break;

                //    case DayOfWeek.Thursday:
                //        listBox4.Items.Add(item);
                //        break;

                //    case DayOfWeek.Friday:
                //        listBox5.Items.Add(item);
                //        break;

                //    case DayOfWeek.Saturday:
                //        listBox6.Items.Add(item);
                //        break;
                //    case DayOfWeek.Sunday:
                //        listBox7.Items.Add(item);
                //        break;

                //}
                
                

            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.AddRange(SingleTon.DB.ChekPoints.Where(u=>u.AbstractTask==(AbstractTask)(sender as ListBox).SelectedItem).ToArray());
        }
    }
}