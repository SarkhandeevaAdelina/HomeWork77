using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork77
{
    public class Director : Company
    {
        protected string directorName;
        public Director(string DirectorName)
        {
            this.directorName = DirectorName;
        }
        public string DirectorName
        {
            get { return directorName; }
            set { directorName = value; }
        }
        public bool TakeTask(string boss, string employer)
        {
            if (boss == Owner & employer == directorName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
