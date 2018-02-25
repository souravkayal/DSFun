using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun
{
    /// <summary>
    /// Employee class 
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// LogHistory class to mantain all log info of employee
    /// </summary>
    public class LogHistory
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public DateTime Date { get; set; }

        public List<LogInfo>  LogInfo { get; set; }
    }
    /// <summary>
    /// To Track of Swipe In and Out
    /// </summary>
    public class LogInfo
    {
        public DateTime SwapIn { get; set; }
        public DateTime SwapOut { get; set; }
    }

    /// <summary>
    /// To mantain Employee log book with some functionality
    /// User will pass employee name, date and time frame. - system will show whether the employee was there in
    /// that time or not
    /// </summary>
    
    public interface IEmployeeOperation
    {
        bool FindAvailability(Employee Emp, DateTime Date, DateTime From, DateTime To);
        double GetTotalWorkingHour(Employee Emp, DateTime Date);
    }
    
    public class EmployeeAttendenceModel : IEmployeeOperation
    {
        List<LogHistory> LogBook;

        //Prepare mock Employee Data
        public EmployeeAttendenceModel()
        {
            LogBook.Add(new LogHistory
            {
                Employee = new Employee { Id = 1, Name = "Sourav" },
                Date = DateTime.Now,
                Id = 1,
                LogInfo = new List<LogInfo>
                {
                           new LogInfo { SwapIn = DateTime.Now , SwapOut = DateTime.Now.AddHours(2)},
                           new LogInfo { SwapIn = DateTime.Now.AddHours(3) , SwapOut = DateTime.Now.AddHours(6)}
                }
            });
        }


        public bool FindAvailability(Employee Emp, DateTime Date, DateTime From, DateTime To)
        {
            var EmployeeInfo = LogBook.Where(f => f.Employee == Emp && f.Date == Date).FirstOrDefault();
            if(EmployeeInfo != null)
            {
                return EmployeeInfo.LogInfo.Where(f => f.SwapIn >= From && f.SwapOut < From).FirstOrDefault() != null ? true : false;
            }
            throw new Exception("Invalid Employee");
        }

        public double GetTotalWorkingHour(Employee Emp, DateTime Date)
        {
            double HourCount = 0;
            var Employee = LogBook.Where(f => f.Employee == Emp && f.Date == Date).FirstOrDefault();
            if(Employee != null)
            {
                foreach (var item in Employee.LogInfo)
                {
                    TimeSpan diff = item.SwapOut - item.SwapIn;
                    HourCount += diff.TotalHours;
                }
            }
            return HourCount;
        }
    }
}
