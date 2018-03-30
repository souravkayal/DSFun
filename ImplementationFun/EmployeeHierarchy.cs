using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun.EmployeeHierarchy
{
    public class Employee
    {
        public int Id { get; set; }
        public int BossId { get; set; }
        public string Name { get; set; }
        public List<Employee> SubOrdinates { get; set; }

        public Employee()
        {
            this.SubOrdinates = new List<Employee>();
        }

    }

    public class EmployeeHierarchy
    {
        //Key is EmployeeId in lookup
        Dictionary<int, Employee> DiscEmp = new Dictionary<int, Employee>();
        public Employee Boss { get; set; }

        public EmployeeHierarchy(Employee Boss)
        {
            DiscEmp.Add(Boss.Id, Boss);
            this.Boss = Boss;
        }

        public void AddEmployee(int BossId, Employee Emp)
        {
            var boss = DiscEmp[BossId];
            DiscEmp.Add(Emp.Id, Emp);

            boss.SubOrdinates.Add(Emp);
        }

        public void PrintAllEmployee(Employee TopBoss)
        {
            if (TopBoss == null || TopBoss.SubOrdinates.Count == 0)
                return;
            else
            {
                var emps = TopBoss.SubOrdinates;
                Queue<Employee> Q = new Queue<Employee>();

                foreach (var item in emps)
                {
                    Console.Write(item.Name);
                    Q.Enqueue(item);
                }
                Console.WriteLine();

                while (Q.Count >0)
                {
                    PrintAllEmployee(Q.Dequeue());
                }
            }

        }

        public List<Employee> GetAllSubOrdinatesOfEmployee(int EmpId)
        {
            return DiscEmp[EmpId].SubOrdinates;
        }        
    }
}
