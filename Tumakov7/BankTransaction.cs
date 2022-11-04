using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov7
{
    internal class BankTransaction
    {

        private readonly double summa;
        public double Summa()
        {
            return summa;
        }
        public BankTransaction(double summa)
        {
            this.summa = summa;
            Console.WriteLine($"Перевод суммы: {summa}");
        }
    }
}
