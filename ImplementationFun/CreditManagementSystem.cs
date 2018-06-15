using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun.CreditManagement
{
    /// <summary>
    /// Model to manage credit to various creditor and to manage ceedit giver 
    /// </summary>
    public enum CreditType
    {
        RealState, Personal, Education
    }

    public class Creditor
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }

    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Credit
    {
        public int Id { get; set; }
        public int CreditorId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreditedOn { get; set; }
        public decimal Amount { get; set; }
        public decimal PercentRate { get; set; }
        public CreditType CreditType { get; set; }
        public IMortgaze Mortgaze { get; set; }
        public int TermInMonth { get; set; }
    }

    public class CreditApplication
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime RequestDate { get; set; }
        public decimal AmountRequested { get; set; }
        public CreditType CreditType { get; set; }
        public int TermInMonth { get; set; }
    }

    public interface IMortgaze
    {

    }

    public class LandMortgaze : IMortgaze
    {
        public int Id { get; set; }
        public string LandInformation { get; set; }
    }
    
    public class GoldMortgaze : IMortgaze
    {
        public int Id { get; set; }
        public string LandInformation { get; set; }
    }

    public class CreditManagementSystem
    {
        public List<Credit> CreditList = new List<Credit>();
        public CreditManagementSystem()
        {

        }

        public List<Credit> GetCreditByWhere(Func<Credit,bool> Where)
        {
            return CreditList.Where(Where).ToList();
        }

        public void AddCredit(CreditApplication Application)
        {
            // Business logic to verify credit score and Other process
            var Credit = new Credit
            {
                Id = 1,
                CreditedOn = DateTime.Now,
                Amount = Application.AmountRequested,
                Mortgaze = new LandMortgaze(),
                PercentRate = 5,
                CreditType = CreditType.Education,
                CustomerId = Application.CustomerId,
                TermInMonth = 15
            };
            CreditList.Add(Credit);

        }


    }
}
