using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnginCalculator
{
    public class Service : IPowerCalculator
    {

      

        public double Power220(double current)
        {

            const double voltage = 220;
            const double cosF = 0.98;
            double result = Math.Round( (voltage * current * cosF) /1000,2);
            
            
            return result;
        }
        public double Power380(double current)
        {
            const double voltage = 380;
            const double cosF = 0.98;
            double result = Math.Round( (voltage * current * cosF * 1.73) / 1000 ,2);

           
            return result;
        }


        public double MainCurrent220( double power)
        {
            const double voltage = 220;
            const double cosF = 0.98;
            double result =Math.Round( (power * 1000) / (voltage * cosF),2);
           
           
            return  result;
            
        }

        public double MainCurrent380( double power)
        {
            const double voltage = 380;
            const double cosF = 0.98;
            double result = Math.Round( (power * 1000) / (Math.Sqrt(3) * voltage * cosF),2);
            
            return result;
        }

        public double? ListAutomats(double current)
        {
            double?[] automats = { 6, 10, 16, 20, 25, 32, 40, 50, 63, 80, 100 };
            return automats.FirstOrDefault(automat => current <= automat);
        }

        
    }
}
