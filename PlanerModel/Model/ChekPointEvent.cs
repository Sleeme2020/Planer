using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planer.Model
{
    public class ChekPointEvent:ChekPoint
    {
        public ChekPointEvent():base(){}
        public ChekPointEvent(string name) : base(name) { }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
