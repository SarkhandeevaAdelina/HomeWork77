using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.IO.Pipes;

namespace Tumakov7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dz81();
            Console.ReadKey();
        }
        public static void up81()
        {
            Console.WriteLine("Введите баланс ТЕКУЩЕГО счета");
            double balance1 = Convert.ToDouble(Console.ReadLine());
            while (!double.TryParse(Console.ReadLine(), out balance1))
            {
                Console.WriteLine("Неверный ввод, повторите попытку!");
            }
            BankAccount bankAccount1 = new BankAccount(balance1);
            BankAccount bankAccount2 = new BankAccount(AccountType.Current);
            Console.WriteLine("Введите баланс СБЕРЕГАТЕЛЬНОГО счета");
            double balance2 = Convert.ToDouble(Console.ReadLine());
            while (!double.TryParse(Console.ReadLine(), out balance2))
            {
                Console.WriteLine("Неверный ввод, повторите попытку!");
            }
            BankAccount bankAccount3 = new BankAccount(AccountType.Saving, balance2);
            Console.WriteLine("Введите название операции (снять/положить)");
            string answer = Console.ReadLine().ToLower();
            while (!answer.Equals("снять") && !answer.Equals("положить"))
            {
                Console.WriteLine("Неверный ввод, повторите!");
            }
            if (answer.Equals("положить"))
            {
                Console.WriteLine("Введите сумму, которую вы хотите положить на счет 1");
                double summ1 = Convert.ToDouble(Console.ReadLine());
                while (!double.TryParse(Console.ReadLine(), out summ1))
                {
                    Console.WriteLine("Неверный ввод, повторите попытку!");
                }
                bankAccount1.Deposit(summ1, bankAccount1);
            }
            else if (answer.Equals("снять"))
            {
                Console.WriteLine("Введите сумму, которую вы хотите снять со счета 2");
                double summ2 = Convert.ToDouble(Console.ReadLine());
                while (!double.TryParse(Console.ReadLine(), out summ2))
                {
                    Console.WriteLine("Неверный ввод, повторите попытку!");
                }
                bankAccount2.WithDrow(summ2, bankAccount2);
                bankAccount2.Dispose();
            }
        }
        public static void up82()
        {
            Console.Write("Введите строку:");
            string s;
            while ((s = Console.ReadLine()) != null)
                Console.WriteLine(new string(s.Reverse().ToArray()));

        }
        public static void up83()
        {
            const string outputFileName = "ResultText.out";
            string inputFileName = string.Empty;

            Console.Write("Введите название входного файла: ");
            inputFileName = Console.ReadLine();

            if (File.Exists(inputFileName))
            {
                File.WriteAllText(outputFileName, File.ReadAllText(inputFileName, Encoding.UTF8).ToUpper(), Encoding.UTF8);
                Console.WriteLine("Результат успешно записан в файл с именем \"{0}\"", outputFileName);
            }
            else
            {
                Console.WriteLine("Файл с именем \"{0}\" не найден!", inputFileName);
            }


        }
        public class Temperature : IFormattable
        {
            private decimal temp;

            public Temperature(decimal temperature)
            {
                if (temperature < -273.15m)
                    throw new ArgumentOutOfRangeException(String.Format("{0} is less than absolute zero.",temperature));
                                                        
                this.temp = temperature;
            }

            public string ToString(string format, IFormatProvider provider)
            {
                return temp.ToString("F2", provider) + " °C";
            }
        }
        static void checkArgImplementInterface(Temperature t)
        {
            IFormattable form, form2;

            if (t is IFormattable)
            {
                form = (IFormattable)t;
            }
            else
            {
                form = null;
            }

            if (form is null)
            {
                Console.WriteLine("Не реализует IFormattable");
            }
            else
            {
                Console.WriteLine("Реализует IFormattable");
            }

            form2 = t as IFormattable;

            if (form2 is null)
            {
                Console.WriteLine("Не реализует IFormattable");
            }
            else
            {
                Console.WriteLine("Реализует IFormattable");
            }
        }

        public static void up84()
        {
            Temperature t = new Temperature(50);
            checkArgImplementInterface(t);
        }
        public static void dz81()
        {
            string way = @"C:\Users\Семья\SOURCE\repos\HomeWork77\Tumakov7\TextFile1.txt";
            string way2 = @"C:\Users\Семья\SOURCE\repos\HomeWork77\Tumakov7\TextFile2.txt";
            Readfileto(way, way2);
            StreamReader reader1 = new StreamReader(way);
            Console.WriteLine(Readstr(reader1.ReadLine()));
            Console.ReadKey();


        }
        public static string Readstr(string v)
        {
            v = v.Split('#')[1];
            return v;
        }
        public static void Readfileto(string way, string way2)
        {
            int k = 0;
            StreamReader reader = new StreamReader(way);
            FileInfo a = new FileInfo(way2);
            a.Create().Dispose();
            StreamWriter writer = new StreamWriter(way2);
            while (reader.ReadLine() != null)
            {
                k++;
            }
            reader.Close();
            StreamReader reader1 = new StreamReader(way);
            for (int i = 0; i < k; i++)
            {
                writer.WriteLine(reader1.ReadLine().Split('#')[1]);
            }
            reader1.Close();
            writer.Close();

        }
        class Songs
        {
            private string name;
            private string author;
            private Songs last_song;
            public Songs() { }
            public Songs(string name, string author)
            {
                this.name = name;
                this.author = author;
                last_song = null;
            }
            public Songs(string name, string author, Songs last_song) { }
            public static void Search(List<Songs> songs)
            {
                bool isFounded = false;
                for (int i = 0; i < songs.Count; i++)
                {
                    for (int j = 1; j < songs.Count - 1; j++)
                    {
                        if (songs[i] != null && songs[j] != null)
                        {
                            if (songs[i].Equals(songs[j]) && i != j)
                            {
                                isFounded = true;
                                Console.WriteLine($"Совпали песни под номерами {i + 1} и {j + 1}, Название {songs[i].name} , автор {songs[i].author} ");
                                songs[i] = null;
                            }
                        }
                    }
                    if (isFounded)
                    {
                        Search(songs);
                    }
                }

            }
            public static string Title(Songs song)
            {
                return $"{song.name} {song.author}";
            }
            public override bool Equals(object obj)
            {
                if (obj is Songs)
                {
                    if ($"{this.name} {this.author}" == Songs.Title(obj as Songs))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public static void dz82()
        {
            int countSongs = 4;
            List<Songs> songs = new List<Songs>();
            for (int i = 0; i < countSongs; i++)
            {
                Console.WriteLine("Введите название песни:");
                string name = Console.ReadLine();
                Console.WriteLine("Введите название артиста:");
                string author = Console.ReadLine();
                songs.Add(new Songs(name, author));
            }
            Songs.Search(songs);
        }
    }
}




