using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planer.Model
{
    public class EventTask : AbstractTask
    {
        public EventTask(string name, string location, DateTime date)
        {
            Name = name;
            Date = date;
            Location = location;
        }

        public EventTask()
        { }
        
        public EventTask(string name,string location):this(name,location,DateTime.Now.AddDays(3))
        {
            
        }

        public DateTime Date { get; set; }
        public string Location { get; set; }

        public override void AddChekPoint(ChekPoint chekPoint)
        {
            if (chekPoint is ChekPointEvent)
                base.AddChekPoint(chekPoint);
            else
                throw new ArgumentException("Не соответствует ChekPointEvent");

        }
    }
}
