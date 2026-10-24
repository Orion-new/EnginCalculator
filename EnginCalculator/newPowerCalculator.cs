using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnginCalculator
{
    public class newPowerCalculator : IPowerCalculator
    {
        public double MainCurrent220(double current, double power)
        {
            const double cosF = 0.98;
            double result = Math.Round((power * 1000) / (current * cosF), 2);


            return result;
        }

        public double MainCurrent380(double current, double power)
        {
            const double cosF = 0.98;
            double result = Math.Round((power * 1000) / (Math.Sqrt(3) * current  * cosF), 2);

            return result;
        }

        public double Power220(double current)
        {
            const double voltage = 220;
            const double cosF = 0.98;
            double result = Math.Round((voltage * current * cosF) / 1000, 2);
            return result;
        }

        public double Power380(double current)
        {
            const double voltage = 380;
            const double cosF = 0.98;
            double result = Math.Round((voltage * current * cosF * Math.Sqrt(3)) / 1000, 2);


            return result;
        }
    }
}
