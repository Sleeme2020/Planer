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
        public static AppDb DB { get; set; }
    }
}
