using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork77
{
    public class Company
    {
        protected string name;
        protected string owner;
        public Company()
        {
            name = "Крутая компания";
            owner = "Борис";
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        public void Print()
        {
            Console.WriteLine($"Генеральный директор = {owner}");
            Console.WriteLine($"Название фирмы = {name}");
        }
    }
}
