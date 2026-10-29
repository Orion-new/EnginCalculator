using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace EnginCalculator
{
    public class HistoreCalculate
    {
        

        private List<CalculationRecord> calculationRecords = new();
        private const string FilePath = "calculation_records.json";


        public void Save()
        {
           string json = JsonSerializer.Serialize(calculationRecords);
              File.WriteAllText(FilePath, json);
        }

        public void Load()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);

                try
                {
                    calculationRecords = JsonSerializer.Deserialize<List<CalculationRecord>>(json) ?? new List<CalculationRecord>();
                }
                catch (JsonException)
                {

                    Console.WriteLine("Файл Пофрежден ");
                    calculationRecords = new();
                }
            }
            else
            {
                Console.WriteLine("Нет записей");
                calculationRecords = new();


            }
        }
        public void AddPower(double x)
        {
            double result = x;
            
           calculationRecords.Add(new CalculationRecord
            {
                Type = "Мощность",
                Value = result,
                Date = DateTime.Now
            });
            
        }

        public void AddCurrent(double x)
        {
            double result = x;
            calculationRecords.Add(new CalculationRecord
            {
                Type = "Ток",
                Value = result,
                Date = DateTime.Now
            });
        }


        public void Show()
        {
            if (calculationRecords.Count > 0) 
            {
                foreach (var record in calculationRecords) 
                {
                    Console.WriteLine($"{record.Date}: {record.Type} - {record.Value}");
                }
            }
            else
            {
                Console.WriteLine("Список пуст ");
            }
            
        }
    }
}
