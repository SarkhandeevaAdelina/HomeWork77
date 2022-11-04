using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork77
{
    internal class Program
    {
        static bool TakeTask(string boss,string employer,List<Department> departments,List<Director> directors,List<Subdivision> subdivisions)
        {
            for (int i = 0; i < 2; i++)
            {
                if (employer == directors[i].DirectorName) //по исполнителю проверяем будет ли он выполнять поручение
                { 
                    return directors[i].TakeTask(boss, employer); //вызываем метод из класса директор
                }
                else if (employer == departments[i].BossOfDepartment || employer == departments[i].DeputyOfBossDepartment) //вызываем метод из класса департамент
                { 
                    return departments[i].TakeTask(boss, employer); 
                }
            }
            if (subdivisions[0].TakeTask(boss, employer) | subdivisions[1].TakeTask(boss, employer)) //вызываем метод из класса подразделение
            { 
                return true; 
            }
            else 
            { 
                return false; 
            }
        }
        static void Main(string[] args)
        {
            Director director1 = new Director("Рашид");
            Director director2 = new Director("О Ильхам");
            Department department1 = new Department("Бухгалтерия", "Лукас", director1.DirectorName);
            Department department2 = new Department("Отдел Информационных технологий", "Оркадий", "Владимир", director2.DirectorName);
            Subdivision subdivision1 = new Subdivision("Системщики", "Ильшат", "Иваныч", department2);
            Subdivision subdivision2 = new Subdivision("Разработчики", "Сергей", "Ляйсан", department2);
            subdivision1.AddNewEmployer("Илья");
            subdivision1.AddNewEmployer("Витя");
            subdivision1.AddNewEmployer("Женя");
            subdivision2.AddNewEmployer("Марат");
            subdivision2.AddNewEmployer("Дима");
            subdivision2.AddNewEmployer("Ильдар");
            subdivision2.AddNewEmployer("Антон");

            List<Department> departments = new List<Department>();
            departments.Add(department1);
            departments.Add(department2);

            List<Director> directors = new List<Director>();
            directors.Add(director1);
            directors.Add(director2);

            List<Subdivision> subdivisions = new List<Subdivision>();
            subdivisions.Add(subdivision1);
            subdivisions.Add(subdivision2);

            int i = 0;
            do
            {
                Console.WriteLine("Кто дает задание?");
                string boss = Console.ReadLine();
                Console.WriteLine("Кто выполняет задание?");
                string employer = Console.ReadLine();

                if (TakeTask(boss, employer, departments, directors, subdivisions))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Задача принята в исполнение");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{employer} не подчиняется напрямую {boss}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                i++;
            }
            while (i < 20);
        }
    }
}
