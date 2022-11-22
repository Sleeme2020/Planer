using Planer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyModel
{
    public interface ITaskModel
    {
        ITask[] GetTask();
        ITask? GetTask(int id);
        bool SetTask(ITask task);
        bool SetTask(ITask[] tasks);
        bool UpdateTask(ITask task);
        bool UpdateTask(ITask[] tasks);
        bool DeleteTask(ITask task);
        bool DeleteTask(int id);
        bool DeleteTask(ITask[] tasks);
        ChekPoint? GetChekPoint(int id);
        ChekPoint[] GetChekPoint();
        ChekPoint[] GetChekPoints(ITask task);
        void RemoveChekPoint(ChekPoint chekPoint);
        void RemoveChekPoint(int id);
        void UpdateChekPoint(ChekPoint chekPoint);
        void AddChekPoint(ChekPoint chekPoint);


    }
}
