using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planer.Model
{
    public class People
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? FirstName { get; set; }


        public override string ToString()
        {
            return $"{Name} {FirstName}";
        }
    }
}
