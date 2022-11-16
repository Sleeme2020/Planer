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
            ChekPointForm chekPointForm;
            var IsDeal = false;
            if (dataGridView1.SelectedCells[0].Value.GetType() == typeof(DealTask))
                IsDeal = true;                
           chekPointForm = new ChekPointForm(IsDeal);          
            
            if(chekPointForm.ShowDialog()==DialogResult.OK)
            {
                ChekPoint chekPoint;
                if (IsDeal)
                {
                    chekPoint = new ChekPointDeal() {AbstractTask= (AbstractTask)dataGridView1.SelectedCells[0].Value, Name = chekPointForm.textBox1.Text, Start = chekPointForm.monthCalendar1.SelectionStart, End = chekPointForm.monthCalendar1.SelectionEnd };
                }
                else
                    chekPoint = new ChekPointEvent() { AbstractTask = (AbstractTask)dataGridView1.SelectedCells[0].Value, Name = chekPointForm.textBox1.Text };

                SingleTon.DB.Add(chekPoint);
                SingleTon.DB.SaveChanges();

                dataGridView1_CellContentClick(dataGridView1, null);
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
            
            //foreach (var task in tasks)
            //{
            //  ListViewItem item = new ListViewItem();
            //    item.SubItems.Add(task.ToString());
            //   listView1.Items.Add(item);
            //}
            BuildListViewPlaner();
        }
        void clearList()
        {
            
        }

        public void BuildListViewPlaner()
        {
            var eventtask = SingleTon.DB.EventTasks.Where(u => u.Date > monthCalendar1.SelectionStart && u.Date < monthCalendar1.SelectionEnd).ToList();
            var dealtask = SingleTon.DB.DealTasks.Where(u => u.Start >= monthCalendar1.SelectionStart && u.End <= monthCalendar1.SelectionEnd).ToList();
            var task = eventtask.Select
                (u => new
                {
                    Id = u.Id,
                    Date = u.Date
                }).Union(dealtask.Select(u => new
                {
                    Id = u.Id,
                    Date = u.Start
                }))                
                .GroupBy(u=>u.Date.DayOfWeek);
            //var tasks = SingleTon.DB.EventTasks.Where(u => u.Date > monthCalendar1.SelectionStart && u.Date < monthCalendar1.SelectionEnd)
            //    .Select(
            //    u => new
            //    {
            //        Id = u.Id,
            //        Date = u.Date
            //    }
            //    ).Union(
            //    SingleTon.DB.DealTasks.Where(u => u.Start >= monthCalendar1.SelectionStart && u.End <= monthCalendar1.SelectionEnd)
            //    .Select
            //    (
            //        u => new
            //        {
            //            Id = u.Id,
            //            Date = u.Start
            //        }
            //        )
            //    ).GroupBy(u => u.Date.DayOfWeek);


            foreach (var item in task)
            {

                if (dataGridView1.Rows.Count < item.Count())
                {
                    for (int i = item.Count(); dataGridView1.Rows.Count < item.Count(); ++i)
                    {
                        dataGridView1.Rows.Add();
                    }
                }
                int j = 0;
                foreach (var tas in item)
                {
                    dataGridView1.Rows[j].Cells["Column" + ((int)item.Key).ToString()].Value = SingleTon.DB.Tasks.Where(u => u.Id == tas.Id).FirstOrDefault();
                    j++;
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

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            checkedListBox1.Items.Clear();
            ChekPoint[] chek = SingleTon.DB.ChekPoints
                .Where(u=>u.AbstractTaskID == ((AbstractTask)((sender as DataGridView).SelectedCells[0].Value)).Id).ToArray();
            foreach(ChekPoint item in chek)
            {
               
                checkedListBox1.Items.Add(item, item.Complite);
                
            }
        }

        private void checkedListBox1_Click(object sender, EventArgs e)
        {
            foreach(var chek in checkedListBox1.Items)
                (chek as ChekPoint).Complite = false;
            foreach (var chek in checkedListBox1.CheckedItems)
            {
                (chek as ChekPoint).Complite = true;
                
            }
            foreach (var chek in checkedListBox1.Items)
                SingleTon.DB.Update((chek as ChekPoint));

            SingleTon.DB.SaveChanges();
        }

 
    }
}