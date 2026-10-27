
using EnginCalculator;

IPowerCalculator service2 = new newPowerCalculator();
HistoreCalculate histore = new();
while (true)
{
    string menuChoice;
    Console.WriteLine("Нажмите 1 чтоб пощитать можность");
    Console.WriteLine("Нажмите 2 чтоб пощитать ток,а так же с каким номиналом вам автомат нужен ");
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
                   
                    histore.AddPower(service2.Power220(current));
                    Console.WriteLine($"Мощность вашей сети {service2.Power220(current)} кВт" );
                    

                }
                else if (resultchoice == 2)
                {
                    double current = ReadDouble("Введите ток");
                    


                    histore.AddPower(service2.Power380(current));
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
                
                double currentPower = ReadDouble("Введите мощность");
                               
                double resultOperation = service2.MainCurrent220( currentPower);

                double? automat = service2.ListAutomats(resultOperation);
                if(automat == null)
                {
                    Console.WriteLine($"Ток в вашей сети {resultOperation} ,нет подходящего автомата из списка");
                }
                else
                {
                    Console.WriteLine($"Ток в вашей сети {resultOperation} ,а автомат вам нужен {automat} A");
                }
                
                histore.AddCurrent(resultOperation);
                
                
                

            }
            else if (newResult == 2)
            {
                
                double currentPower = ReadDouble("Введите мощность");
                double resultOperation = service2.MainCurrent380( currentPower);

                double? automat = service2.ListAutomats(resultOperation);
                if (automat == null)
                {
                    Console.WriteLine($"Ток в вашей сети {resultOperation} ,нет подходящего автомата из списка");
                }
                else
                {
                    Console.WriteLine($"Ток в вашей сети {resultOperation} ,а автомат вам нужен {automat} A");
                }
                histore.AddCurrent(resultOperation);
                
                
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

       
    }
    
}
double ReadDouble(string prompt)
{
    Console.WriteLine(prompt);
    double result = 0;
    while (!double.TryParse(Console.ReadLine(), out result) || result <= 0) Console.WriteLine(prompt);



    return result;
}
