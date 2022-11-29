using Planer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ProxyModel
{
    public class TaskModel : ITaskModel
    {
        AppContext DB;

        public TaskModel()
        {
            DB= new AppContext();
        }

        public void AddChekPoint(ChekPoint chekPoint)
        {
            if(chekPoint!=null)
            {
                DB.ChekPoints.Add(chekPoint);
                DB.SaveChangesAsync();
            }
        }

        public bool DeleteTask(ITask task)
        {
            
            if(task is AbstractTask)
            {
                try
                {
                    DB.Tasks.Remove(task as AbstractTask);
                    DB.SaveChangesAsync();
                    return true;
                }catch(Exception e)
                {
                    return false;
                }
            }
            throw new ArgumentException("Не верный аргумент");
        }

        public bool DeleteTask(int id)
        {
            var task = DB.Tasks.Where(t=>t.Id==id).FirstOrDefault();
            if (task is not null)
            {
                DB.Tasks.Remove(task);
                DB.SaveChangesAsync();
                return true;
            }else
            {
                throw new ArgumentNullException($"таск с ИД-{id} не найден");
            }
            throw new NotImplementedException("Что пошло не так");
        }

        public bool DeleteTask(ITask[] tasks)
        {
            if(tasks is AbstractTask[])
            {
                try
                {
                    DB.Tasks.RemoveRange(tasks as AbstractTask[]);
                    DB.SaveChangesAsync();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            throw new ArgumentException("Не верный аргумент");
        }

        public ChekPoint? GetChekPoint(int id)
        {
            return DB.ChekPoints.Where(x => x.Id == id).FirstOrDefault();
        }

        public ChekPoint[] GetChekPoint()
        {
            DB.ChekPoints.Load();            
           return DB.ChekPoints.ToArray();
        }

        public ChekPoint[] GetChekPoints(ITask task)
        {
            if(task is AbstractTask)
            {
                if(task is not null)
                {
                    return DB.ChekPoints.Where(x=>x.AbstractTaskID ==(task as AbstractTask).Id).ToArray();
                }
            }
            throw new ArgumentException();
        }

        public AbstractTask[] GetTask()
        {
            DB.Tasks.Load();
            return DB.Tasks.ToArray();
        }

        public ITask? GetTask(int id)
        {
            return DB.Tasks.Where(u => u.Id == id).FirstOrDefault();
            
        }

        public void RemoveChekPoint(ChekPoint chekPoint)
        {
            if (chekPoint != null)
            {
                DB.ChekPoints.Remove(chekPoint);
                DB.SaveChangesAsync();
            }
        }
        public void RemoveChekPoint(int id)
        {
            var task = DB.ChekPoints.Where(x => x.Id == id).FirstOrDefault();
            if (task != null)
            {
                DB.ChekPoints.Remove(task);
                DB.SaveChangesAsync();
            }
        }

        public bool SetTask(ITask task)
        {
            if(task is AbstractTask)
            {
                if (task != null)
                {
                    DB.Tasks.Add(task as AbstractTask);
                    DB.SaveChangesAsync();
                    return true;
                }
            }
            throw new ArgumentException();
        }

        public bool SetTask(ITask[] tasks)
        {
            if (tasks is AbstractTask[])
            {
                if (tasks != null)
                {
                    DB.Tasks.AddRange(tasks as AbstractTask[]);
                    DB.SaveChangesAsync();
                    return true;
                }
            }
            throw new ArgumentException();
        }

        public void UpdateChekPoint(ChekPoint chekPoint)
        {
            DB.ChekPoints.Update(chekPoint);
            DB.SaveChanges();
        }

        public bool UpdateTask(ITask task)
        {
            if(task is AbstractTask)
            {
                if(task != null)
                {
                    DB.Tasks.Update(task as AbstractTask);
                    DB.SaveChangesAsync();
                    return true;
                }
            }
            throw new ArgumentException();
        }

        public bool UpdateTask(ITask[] tasks)
        {
            if(tasks is AbstractTask[])
            {
                if(tasks!= null)
                {
                    DB.Tasks.UpdateRange(tasks as AbstractTask[]);
                    DB.SaveChangesAsync();
                    return true;
                }
            }
            throw new ArgumentException();
        }
    }
}
