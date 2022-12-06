using Planer.Model;
using PlanerWPF.Comand;
using PlanerWPF.Interface;
using ProxyModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PlanerWPF.Patterns;

namespace PlanerWPF.ViewModel
{
    
    internal class EventViewModel : INotifyPropertyChanged, IOwnerContext
    {
        public string NameEvent { get; set; }
        public ObservableCollection<People> peoples { get; set; }
        public People SelectPeople { get; set; }
        public bool DealChek { get; set; }
        public bool EventChek { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public string Location { get; set; }

        public EventViewModel()
        {
            DateTimeStart = DateTime.Now;
            DateTimeEnd = DateTime.Now;
            peoples = new();
            var pep = SingleTon.DataContext.GetUser();
            foreach (var p in pep)
                peoples.Add(p);
        }


        public IOwnerContext OwnerContext { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void GetViewContext(object? obj)
        {
            throw new NotImplementedException();
            
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        AbstractTask buildTask()
        {
            AbstractTask task = null;
            if (DealChek)
                task= new DealTask();
            if (EventChek)
                task= new EventTask();
            task.People = SelectPeople;
            task.Name = NameEvent;
            switch(task)
            {
                case DealTask t:
                    t.Start = DateTimeStart;
                    t.End = DateTimeEnd;
                    break;

                 case EventTask t:
                    t.Date = DateTimeStart;
                    t.Location = Location;
                    break;
            }

            return task;
        }



        RelayCommand? _Saved;
        public RelayCommand Saved
        {
            get
            {
                return _Saved ??
                  (_Saved = new RelayCommand((o) =>
                  {                      
                      
                      OwnerContext.GetViewContext(buildTask());
                  }));
            }
        }

    }
}
