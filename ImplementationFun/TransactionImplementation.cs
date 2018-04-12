using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun
{
    /// <summary>
    /// https://www.careercup.com/question?id=5141919683313664
    /// </summary>
    public enum Option
    {
        Create, Update, Delete
    }

    public class Operation
    {
        public int RowId { get; set; }
        public Option Option { get; set; }
    }

    public class TransactionImplementation
    {
        Queue<Operation> Operations = new Queue<Operation>();
        bool IsTransactionStarted { get; set; }

        void AddInOperationalQueue(Operation Op)
        {
            Operations.Enqueue(Op);
        }

        public void Create(Operation Command)
        {
            if (IsTransactionStarted)
                Operations.Enqueue(Command);
            else
                throw new Exception("Transaction not started");
        }

        public void Update(Operation Command)
        {
            if (IsTransactionStarted)
                Operations.Enqueue(Command);
            else
                throw new Exception("Transaction not started");
        }
        public void Delete(Operation Command)
        {
            if (IsTransactionStarted)
                Operations.Enqueue(Command);
            else
                throw new Exception("Transaction not started");
        }

        //Rollback the transaction
        public void RollbackTransaction()
        {
            Operations.Clear();
        }

        //Commit Transaction
        public void Commit()
        {
            if(IsTransactionStarted)
            {
                if(Operations.Count > 0)
                {
                    while (Operations.Count >0)
                    {
                        //Process the command
                        Console.WriteLine(Operations.Dequeue());
                    }
                }
                IsTransactionStarted = false;
            }

        }
    }
}
