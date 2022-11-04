using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork77
{
    public class Department : Director
    {
        protected string nameOfDepartment;
        protected string bossOfDepartment;
        protected string deputyOfBossDepartment;
        public Department(string NameOfDepartment, string BossOfDepartment, string DirectorName) : base(DirectorName)
        {
            this.nameOfDepartment = NameOfDepartment;
            this.bossOfDepartment = BossOfDepartment;
        }
        public Department(string NameOfDepartment, string BossOfDepartment, string DeputyOfBossDepartment, string DirectorName) : base(DirectorName)
        {
            this.nameOfDepartment = NameOfDepartment;
            this.bossOfDepartment = BossOfDepartment;
            this.deputyOfBossDepartment = DeputyOfBossDepartment;
        }
        public string NameOfDepartment
        {
            get { return nameOfDepartment; }
            set { nameOfDepartment = value; }
        }
        public string BossOfDepartment
        {
            get { return bossOfDepartment; }
            set { bossOfDepartment = value; }
        }
        public string DeputyOfBossDepartment
        {
            get { return deputyOfBossDepartment; }
            set { deputyOfBossDepartment = value; }
        }
        public new bool TakeTask(string boss, string employer)
        {
            if (boss == DirectorName & employer == BossOfDepartment | boss == BossOfDepartment & employer == DeputyOfBossDepartment) 
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
