
using EnginCalculator;

IPowerCalculator service = new Service();
IPowerCalculator service2 = new newPowerCalculator();
HistoreCalculate histore = new();
while (true)
{
    string menuChoice;
    Console.WriteLine("Нажмите 1 чтоб пощитать можность");
    Console.WriteLine("Нажмите 2 чтоб пощитать ток чтоб знать какие автоматы установить");
    Console.WriteLine("Нажми 3 что б узнать все данные");
    Console.WriteLine("Нажми 4 что б выйти");

    menuChoice = Console.ReadLine();

    if (!int.TryParse(menuChoice, out int result))
    {
        Console.WriteLine("Введите число ");
        continue;
    }
    else
    {
        if (result == 1)
        {
            string choice;
            Console.WriteLine("Если у вас однофазнать сеть нажмите 1 ,аесли 3х-фазная то 2");
            choice = Console.ReadLine();
            if (!int.TryParse(choice, out int resultchoice))
            {
                Console.WriteLine("Введите корректное число");
                continue;


            }
            else
            {
                if (resultchoice == 1)
                {
                    double current = ReadDouble("Введите ток");
                   
                    histore.AddPower(service.Power220(current));
                    Console.WriteLine($"Мощность вашей сети {service.Power220(current)} кВт" );
                    Console.WriteLine($"Мощность вашей сети {service2.Power220(current)} кВт");

                }
                else if (resultchoice == 2)
                {
                    double current = ReadDouble("Введите ток");
                    


                    histore.AddPower(service.Power380(current));
                    Console.WriteLine($"Мощность вашей сети {service.Power380(current)} кВт");
                    Console.WriteLine($"Мощность вашей сети {service2.Power380(current)} кВт");


                }
            }
        }
        else if (result == 2)
        {
            string choice;
            Console.WriteLine("если у вас цепь 220 нажмите 1,а если 380 нажмите 2");
            choice = Console.ReadLine();
            if (!int.TryParse(choice, out int newResult))
            {
                Console.WriteLine("Введите корректное число");
                continue;
            }
            else if (newResult == 1)
            {
                double current = ReadDouble("Введите напряжение");
                double currentPower = ReadDouble("Введите мощность");
                               
                
                histore.AddCurrent(service.MainCurrent220(current, currentPower));
                Console.WriteLine($"Ток в вашей сети {service.MainCurrent220(current, currentPower)}");
                Console.WriteLine($"Ток в вашей сети {service2.MainCurrent220(current, currentPower)}");


            }
            else if (newResult == 2)
            {
                double current = ReadDouble("Введите напряжение");
                double currentPower = ReadDouble("Введите мощность");
                
                histore.AddCurrent(service.MainCurrent380(current, currentPower));
                Console.WriteLine($"Ток в вашей сети {service.MainCurrent380(current , currentPower)}");
                Console.WriteLine($"Ток в вашей сети {service2.MainCurrent380(current, currentPower)}");
            }
        }
        else if (result == 3)
        {
            histore.Show();
        }
        else if (result == 4)
        {
            break;
        }
        else if (result > 4)
        {
            Console.WriteLine("Вы ввели числа которых нет в списке,введите корректное число");
        }

       double ReadDouble(string x)
        {
            Console.WriteLine(x);
            double result = 0;
            while (!double.TryParse(Console.ReadLine(), out result  ) || result <= 0) Console.WriteLine(x);
            
            
            
            return result;
        }
    }
}
