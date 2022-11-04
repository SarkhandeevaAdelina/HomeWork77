using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork77
{
    public class Subdivision
    {
        protected string direction;
        protected string head;
        protected string subhead;
        protected Department dep;
        protected List<string> employee = new List<string>();
        public Subdivision(string Direction, string Head, string Subhead, Department Dep)
        {
            this.direction = Direction;
            this.head = Head;
            this.subhead = Subhead;
            this.dep = Dep;
        }
        public string Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        public string Head
        {
            get { return direction; }
            set { direction = value; }
        }
        public string Subhead
        {
            get { return subhead; }
            set { subhead = value; }
        }
        public void AddNewEmployer(string name)
        {
            employee.Add(name);
        }
        public bool TakeTask(string boss, string employer)
        {
            if (employee.Contains(employer))
            {
                if (boss == head | boss == subhead) 
                { 
                    return true; 
                }
                else 
                { 
                    return false; 
                }
            }
            else if (employer == subhead & boss == head) 
            { 
                return true; 
            }
            else if (employer == head & boss == dep.BossOfDepartment | boss == dep.DeputyOfBossDepartment) 
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
