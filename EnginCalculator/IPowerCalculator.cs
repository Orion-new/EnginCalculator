using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnginCalculator
{
    public interface IPowerCalculator
    {
       public double Power220(double x);

        public double Power380(double x);

        public double MainCurrent220(double x ,double y);

        public double MainCurrent380(double x,double y);

        
    }
}
