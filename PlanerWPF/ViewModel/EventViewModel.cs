using PlanerWPF.Comand;
using PlanerWPF.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PlanerWPF.ViewModel
{
    internal class EventViewModel : INotifyPropertyChanged,IOwnerContext
    {
        public IOwnerContext OwnerContext { get; set ; }

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
        RelayCommand? _Saved;
        public RelayCommand Saved
        {
            get
            {
                return _Saved ??
                  (_Saved = new RelayCommand((o) =>
                  {
                      //вместо obj Подготовить объект из контекста
                      OwnerContext.GetViewContext(new object());
                  }));
            }
        }

    }
}
