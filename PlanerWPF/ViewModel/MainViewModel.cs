using Planer.Model;
using PlanerWPF.Comand;
using ProxyModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PlanerWPF.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        #region События
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Служебные ViewObj
        public class ViewTask
        {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public string Name { get; set; }
        }

        TaskModel TaskModel{ get; set; }

        #endregion


        RelayCommand? _EditChekPoint;
        public RelayCommand EditChekPoint
        {
            get
            {
                return _EditChekPoint ??
                  (_EditChekPoint = new RelayCommand((o) =>
                  {
                      TaskModel.UpdateChekPoint(o as ChekPoint);

                  }));
            }
        }

        List<IGrouping<DayOfWeek, ViewTask>> _viewtasks;
        DateTime _SelectStartDate;
        DateTime _SelectEndDate;
        DateTime[] _RangeDateSelected;


        ObservableCollection<ViewTask> _Monday;
        ObservableCollection<ViewTask> _Tuesday;
        ObservableCollection<ViewTask> _Wednesday;
        ObservableCollection<ViewTask> _Thursday;
        ObservableCollection<ViewTask> _Friday;
        ObservableCollection<ViewTask> _Saturday;
        ObservableCollection<ViewTask> _Sunday;

        public ObservableCollection<ViewTask> Monday
        {
            get { return _Monday; }
            set
            {
                _Monday = value;                
                OnPropertyChanged("Monday");
            }
        }

        public ObservableCollection<ViewTask> Tuesday
        {
            get { return _Tuesday; }
            set
            {
                _Tuesday = value;
                OnPropertyChanged("Tuesday");
            }
        }
        public ObservableCollection<ViewTask> Wednesday
        {
            get { return _Wednesday; }
            set
            {
                _Wednesday = value;
                OnPropertyChanged("Wednesday");
            }
        }
        public ObservableCollection<ViewTask> Thursday
        {
            get { return _Thursday; }
            set
            {
                _Thursday = value;
                OnPropertyChanged("Thursday");
            }
        }
        public ObservableCollection<ViewTask> Friday
        {
            get { return _Friday; }
            set
            {
                _Friday = value;
                OnPropertyChanged("Friday");
            }
        }
        public ObservableCollection<ViewTask> Saturday
        {
            get { return _Saturday; }
            set
            {
                _Saturday = value;
                OnPropertyChanged("Saturday");
            }
        }
        public ObservableCollection<ViewTask> Sunday
        {
            get { return _Sunday; }
            private set
            {
                _Sunday = value;
                OnPropertyChanged("Sunday");
            }
        }
        ViewTask _SelectedItem;
        public ViewTask SelectedItem
        {
            get { return _SelectedItem; }
            set {
                _SelectedItem = value;
                UdpPoint();
            }
        }

        ObservableCollection<ChekPoint> _ChekPoints;
        public ObservableCollection<ChekPoint> ChekPoints
        {
            get { return _ChekPoints; }
            set
            {
                _ChekPoints = value;
                OnPropertyChanged("ChekPoints");
            }
        }
        void UdpPoint()
        {
            var point = TaskModel.GetChekPoint()
                .Where(u=>u.AbstractTaskID == SelectedItem?.Id).ToList();
            ChekPoints?.Clear();
            foreach (var item in point)
                ChekPoints.Add(item);
            
        }

        void sortDay(List<IGrouping<DayOfWeek, ViewTask>>? obj)
        {
            clearDay();
            
          if(obj == null) return;
            foreach( var item in obj)
            {
                ObservableCollection<ViewTask> a = new();
                foreach (var item2 in item)
                    a.Add(item2);
                var prop = GetType().GetProperties();
                var p = prop.FirstOrDefault(x => item.Key.ToString() == x.Name);
                if (p == null)
                    return;
                p.SetValue(this, a, null);
                
                }
            }
        void clearDay()
        {
            Monday?.Clear();
            OnPropertyChanged("Monday");
            Tuesday?.Clear();
            OnPropertyChanged("Tuesday");
            Wednesday?.Clear();
            OnPropertyChanged("Wednesday");
            Thursday?.Clear();
            OnPropertyChanged("Thursday");
            Friday?.Clear();
            OnPropertyChanged("Friday");
            Saturday?.Clear();
            OnPropertyChanged("Saturday");
            Sunday?.Clear();
            OnPropertyChanged("Sunday");

        }

        public List<IGrouping<DayOfWeek, ViewTask>> ViewTasks
        {
            get { return _viewtasks; }
            set
            {
                _viewtasks = value;
                sortDay(value);
                
            }
        }
        public DateTime SelectStartDate
        {
            get { return _SelectStartDate==new DateTime()?DateTime.Now:_SelectStartDate; }
            set
            {
                _SelectStartDate = value;                
                OnPropertyChanged("SelectStartDate");
                UpdateTask();
            }
        }

        public DateTime SelectEndDate
        {
            get { return _SelectEndDate == new DateTime() ? DateTime.Now : _SelectEndDate; }
            set
            {
                _SelectEndDate = value;                
                OnPropertyChanged("SelectEndDate");
                UpdateTask();
            }
        }

        public DateTime[] RangeDateSelected
        {
            get { return _RangeDateSelected; }
            set
            {
                _RangeDateSelected = value;
                if (value.Length > 0)
                {
                    Array.Sort(_RangeDateSelected);
                    _SelectStartDate = _RangeDateSelected[0];
                    _SelectEndDate = _RangeDateSelected[value.Length-1];
                }
                OnPropertyChanged("RangeDateSelected");
            }
        }

        public MainViewModel()
        {
            TaskModel = new();
            UpdateTask();
            _SelectEndDate = DateTime.Now;
            _SelectStartDate = DateTime.Now;
            _ChekPoints = new();
        }


        public void UpdateTask()
        {
            var task = TaskModel.GetTask();
            var eventtask = (task.Where(x => x.GetType() == typeof(EventTask))).ToArray();
            var eventtasknew = eventtask.Select(x => (EventTask)x).Where(x=>x.Date>_SelectStartDate && x.Date<=_SelectEndDate);
            var dealtask = (task.Where(x => x.GetType() == typeof(DealTask))).ToArray();
            var dealtasknew =  dealtask.Select(x=>(DealTask)x).Where(x=>x.Start>_SelectStartDate && x.End<=_SelectEndDate);
            ViewTasks = eventtasknew?.Select
                (u => new ViewTask
                {
                    Id = u.Id,
                    Date = u.Date,
                    Name = u.Name
                }).Union(dealtasknew?.Select(u => new ViewTask
                {
                    Id = u.Id,
                    Date = u.Start,
                    Name = u.Name
                }))
                .GroupBy(u => u.Date.DayOfWeek).ToList();

            //this.ViewTasks = )ViewTasks;
        }

    }
}
