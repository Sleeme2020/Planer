using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Planer.Model
{
    public abstract class AbstractTask
    {
        public int Id
        {
            get ;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public People? People { get; set; }
        public int PeopleId { get; set; }

        public List<ChekPoint>? ChekPoints { get; set; }

        public AbstractTask():this("Имя собития")
        {

        }

        public AbstractTask(string name)
        {
            Name = name;
        }

        public AbstractTask(string name, People people):this(name)
        {
            People = people;
        }
       

        public virtual void AddChekPoint(ChekPoint chekPoint)
        {
            chekPoint.AbstractTask = this;
            ChekPoints.Add(chekPoint);
        }

    }
}