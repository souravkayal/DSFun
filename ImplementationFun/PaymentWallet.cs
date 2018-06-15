using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun.PaymentWallet
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string QRCode { get; set; }
        public UserWallet Wallet { get; set; }
    }

    public class UserWallet
    {
        public int Id { get; set; }
        public decimal CurrentBalance { get; set; }
        public List<Transaction> Transactions { get; set; }
    }

    public class Transaction
    {
        public string Id { get; set; }
        public User From { get; set; }
        public User To { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionTime { get; set; }
        public TransactionType TransactionType { get; set; }
        public bool Status { get; set; }
    }

    public enum TransactionType
    {
        Credit, Debit
    }

    public class MicroWallet
    {
        public List<User> Users = new List<User>();
        public MicroWallet()
        { }

        public void AddUser(User User)
        {
            Users.Add(User);
        }

        public void TransferAmount(int FromId, int ToId, int Amount)
        {
            var userFrom = Users.Where(f => f.Id == FromId).FirstOrDefault();
            var userTo = Users.Where(f => f.Id == ToId).FirstOrDefault();

            //Keep this code in transaction
            if(userFrom.Wallet.CurrentBalance > Amount)
            {
                userFrom.Wallet.CurrentBalance -= Amount;
                string transId = Guid.NewGuid().ToString();

                var fromTransaction = new Transaction { Id = transId , Amount = Amount, From = userFrom, To = userTo, TransactionTime = DateTime.Now, TransactionType = TransactionType.Debit };
                var toTransaction = new Transaction { Id = transId, Amount = Amount, From = userFrom, To = userTo, TransactionTime = DateTime.Now, TransactionType = TransactionType.Credit };
                userFrom.Wallet.Transactions.Add(fromTransaction);
                userTo.Wallet.CurrentBalance += Amount;
                userTo.Wallet.Transactions.Add(toTransaction);
            }
        }

        public User GetUser(Func<User, bool> Where)
        {
            return Users.Where(Where).FirstOrDefault();
        }
    }
}
