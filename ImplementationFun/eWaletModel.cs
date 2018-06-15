using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun.eWaltet
{

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Address Address { get; set; }
        public Queue<Transaction> Tranctions { get; set; }

        public decimal CurrentBalance { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
    }

    public class Transaction
    {
        public int Id { get; set; }
        public int FromId { get; set; }
        public int ToID { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
        public TransactionType TransactionType { get; set; }
    }

    public enum TransactionType
    {
        Credit, Debit
    }
    
    public class eWaletModel
    {
        List<User> Users = new List<User>();

        public void AddUser(User Item)
        {
            Users.Add(Item);
        }

        public void TransferAmount(User From, User To, decimal Amount)
        {
            Transaction tr = new Transaction { Amount = Amount, FromId = From.Id, ToID = To.Id, DateTime = DateTime.Now };
            var from_account = Users.Where(f => f.Id == From.Id).FirstOrDefault();
            var to_account = Users.Where(f => f.Id == To.Id).FirstOrDefault();


            //This should be in lock
            tr.TransactionType = TransactionType.Debit;
            from_account.Tranctions.Enqueue(tr);
            from_account.CurrentBalance -= Amount;

            tr.TransactionType = TransactionType.Credit;
            to_account.Tranctions.Enqueue(tr);
            to_account.CurrentBalance += Amount;            
        }

        public List<Transaction> GetAllTransactionByUser(User Item)
        {
            return Users.Where(f => f.Id == Item.Id).First().Tranctions.ToList();
        }

    }
}
