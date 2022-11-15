using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planer.AppContext;

namespace Planer
{
    public static class SingleTon
    {
        static SingleTon()
        {
            DB = new AppDb();
        }
        public static AppDb DB { get; set; }
    }
}
