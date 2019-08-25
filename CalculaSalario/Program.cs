using System;
using System.Globalization;
using CalculaSalario.Entities;
using CalculaSalario.Entities.Enums;

namespace CalculaSalario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nome do departamento: ");
            string deptName = Console.ReadLine();

            Console.WriteLine("\nEntre com os dados do Trabalhador\n");

            Console.Write("Nome: ");
            string name = Console.ReadLine();

            Console.Write("Nível (Junior/Intermediário/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Salário Base: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("Quantos contratos para este trabalhador? : ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("\nEntre com a data do {0}º Contrato\n", i );

                Console.Write("Data (DD/MM/AAAA): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("Vapor por Hora: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Duração (Horas): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);

                worker.AddContract(contract);
            }

            Console.Write("\nEntre com o Mês e Ano (MM/AAAA) para calcular o ganho: ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("\nNome: " + worker.Name+ "\nDepartamento: " + worker.Department.Name+ "\nGanho de " + monthAndYear+": R$"+worker.Income(year,month).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
