using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planer.Model
{
    public class ChekPointDeal: ChekPoint
    {
        public ChekPointDeal(string name, DateTime end) : this(name, DateTime.Now, end) { }
        public ChekPointDeal(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
        public ChekPointDeal(string name, DateTime start, DateTime end) : this(start, end) 
        {
            Name = name;
        }
        public ChekPointDeal()
        {

        }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
