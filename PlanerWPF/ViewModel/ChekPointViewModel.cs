using Planer.Model;
using PlanerWPF.Comand;
using PlanerWPF.Interface;
using PlanerWPF.Patterns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanerWPF.ViewModel
{
    internal class ChekPointViewModel : INotifyPropertyChanged, IOwnerContext
    {
        public IOwnerContext OwnerContext { get ; set ; }
               
        public int TaskId { get; set ; }

        public string NameChekPoint { get; set; }

        public DateTime Date { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        object BuildChekpiont()
        {
            var task=SingleTon.DataContext.GetTask(TaskId) as AbstractTask;
            ChekPoint? chek =null;
            switch(task)
            {
                case EventTask _:
                    chek = new ChekPointEvent();  
                    
                    break;
                case DealTask _:
                    chek = new ChekPointDeal();
                    (chek as ChekPointDeal).Start = Date;
                    break;

            }


            chek.Name = NameChekPoint;
            chek.AbstractTask = task;
            return chek;
        }

        public ChekPointViewModel()
        {
            Date = DateTime.Now;
        }


        RelayCommand? _Saved;
        public RelayCommand Saved
        {
            get
            {
                return _Saved ??
                  (_Saved = new RelayCommand((o) =>
                  {

                      OwnerContext.GetViewContext(BuildChekpiont());
                  }));
            }
        }

        public void GetViewContext(object? obj)
        {
            
            throw new NotImplementedException();
        }
    }
}
