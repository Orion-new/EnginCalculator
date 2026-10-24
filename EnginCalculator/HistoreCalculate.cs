using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace EnginCalculator
{
    public class HistoreCalculate
    {
        public List<string> services = new();

        public void AddPower(double x)
        {
            double result = x;
            string list = $"Мощность вашей цепи {result}";
            services.Add(list);
        }

        public void AddCurrent(double x)
        {
            double result = x;
            string list = $"Ток вашей цепи {result}";
            services.Add(list);
        }


        public void Show()
        {
            if (services.Count > 0) 
            {
                foreach (var service in services) 
                {
                    Console.WriteLine(service.ToString());
                }
            }
            else
            {
                Console.WriteLine("Список пускт");
            }
            
        }
    }
}
