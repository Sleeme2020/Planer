using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planer.Model
{
    public abstract class ChekPoint
    {
        public ChekPoint():this("Какое-то Дело")
        {
            
        }

        public ChekPoint(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public bool Complite { get; set; }
        public AbstractTask AbstractTask { get; set; }
        public int AbstractTaskID { get; set; }
    }
}
