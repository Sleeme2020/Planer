using ProxyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanerWPF.Patterns
{
    internal static class SingleTon
    {
        public static TaskModel DataContext { get; set; }
        static SingleTon()
        {
            DataContext = new();
        }
    }
}
