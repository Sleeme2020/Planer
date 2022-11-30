using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanerWPF.Interface
{
    public interface IOwnerContext
    {
        IOwnerContext  OwnerContext {get;set;}
        void GetViewContext(object? obj);
    }
}
