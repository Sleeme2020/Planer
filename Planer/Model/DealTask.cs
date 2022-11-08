using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planer.Model
{
    public class DealTask:AbstractTask
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public override void AddChekPoint(ChekPoint chekPoint)
        {
            if (chekPoint is ChekPointDeal)
            {
                var chekPointtmp = chekPoint as ChekPointDeal;
                if (chekPointtmp?.Start >= this.Start && chekPointtmp?.End <= this.End)
                    base.AddChekPoint(chekPoint);
                else
                    throw new ArgumentException("Не соответствует диапазон");

            }            
            else
                throw new ArgumentException("Не соответствует ChekPointDeal");

        }


    }
}
