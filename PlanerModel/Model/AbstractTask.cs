using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Planer.Model
{
    public abstract class AbstractTask : ITask
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


        void ITask.AddChekPoint(Planer.Model.ChekPoint chekPoint)
        {
            this.AddChekPoint(chekPoint);
        }

        public virtual void AddChekPoint(ChekPoint chekPoint)
        {            
            chekPoint.AbstractTask = this;
            ChekPoints.Add(chekPoint);
        }

        public override string ToString()
        {
            return $"{Name}";
        }

    }
}