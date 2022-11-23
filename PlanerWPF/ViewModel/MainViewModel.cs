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


        ObservableCollection<IGrouping<DayOfWeek, ViewTask>> _viewtasks;
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

        ObservableCollection<ViewTask> Monday
        {
            get { return _Monday; }
            set
            {
                _Monday = value;
                OnPropertyChanged("Monday");
            }
        }

        public ObservableCollection<IGrouping<DayOfWeek, ViewTask>> ViewTasks
        {
            get { return _viewtasks; }
            set
            {
                _viewtasks = value;
                OnPropertyChanged("ViewTasks");
            }
        }
        public DateTime SelectStartDate
        {
            get { return _SelectStartDate==new DateTime()?DateTime.Now:_SelectStartDate; }
            set
            {
                _SelectStartDate = value;
                OnPropertyChanged("SelectStartDate");
            }
        }

        public DateTime SelectEndDate
        {
            get { return _SelectEndDate == new DateTime() ? DateTime.Now : _SelectEndDate; }
            set
            {
                _SelectEndDate = value;
                OnPropertyChanged("SelectEndDate");
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
        }


        public void UpdateTask()
        {
            var task = TaskModel.GetTask();
            var eventtask = (task.Where(x => x.GetType() == typeof(EventTask))).ToArray();
            var eventtasknew = (eventtask as EventTask[])?.Where(u => u.Date > SelectStartDate && u.Date < SelectEndDate).ToList();
            var dealtask = (task.Where(x => x.GetType() == typeof(DealTask))).ToArray();
            var dealtasknew =  (dealtask as DealTask[])?.Where(u => u.Start >= SelectStartDate && u.End <= SelectEndDate).ToList();
            var ViewTasks = eventtasknew?.Select
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
        }

    }
}
