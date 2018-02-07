using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun
{
    //Design and implementation of call center process
    //Few Very important functionality of call center has implemented here
    public class Customer
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
    }
    public enum WorkStatus
    {
        Free, InCall, InBreak
    }
    public class Executive
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public string CounterId { get; set; }
        public WorkStatus WorkStatus { get; set; }
        public Executive Manager { get; set; }
        public Call Call { get; set; }
    }
    public class Call
    {
        public string Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime CallAt { get; set; }
        public DateTime CalEnd { get; set; }
    }
    public class CallProcess
    {
        Queue<Customer> CustomerQ = new Queue<Customer>();
        Queue<Executive> ExecutiveQ = new Queue<Executive>();

        //Dictionary Mapping to callid-executive is for O(1) searching in time of Call End
        Dictionary<string, Executive> callExecutiveMapping = new Dictionary<string, Executive>();

        //Populate static caller and executive
        public CallProcess()
        {
            CustomerQ.Enqueue(new Customer { Id = 1 });
            CustomerQ.Enqueue(new Customer { Id = 2 });
            CustomerQ.Enqueue(new Customer { Id = 3 });

            ExecutiveQ.Enqueue(new Executive { Id = 1 });
            ExecutiveQ.Enqueue(new Executive { Id = 2 });
            ExecutiveQ.Enqueue(new Executive { Id = 3 });
        }

        public void AddCustomerInQueue(Customer Customer)
        {
            CustomerQ.Enqueue(Customer);
        }
        public void ProcessCall()
        {
            AssignCallToExecutive(CustomerQ.Dequeue());
        }
        public void AssignCallToExecutive(Customer Customer)
        {
            int ExecutiveCount = ExecutiveQ.Count();
            int IndexCount = 0;

            while (true)
            {
                var item = ExecutiveQ.Dequeue();
                if (item.WorkStatus == WorkStatus.Free)
                {
                    string callId = Guid.NewGuid().ToString();
                    item.Call = new Call { Id = callId, Customer = Customer };
                    item.WorkStatus = WorkStatus.InCall;

                    //Populate Mapping for O(1) complexcity to End call
                    callExecutiveMapping.Add(callId, item);

                    ExecutiveQ.Enqueue(item);
                    break;
                }
                else
                {
                    ExecutiveQ.Enqueue(item);
                    ++IndexCount;
                }

                if (IndexCount >= ExecutiveCount)
                {
                    throw new Exception("All Executives are busy");
                }
            }
        }
        public void SetCallEnded(string CallerId)
        {
            if (callExecutiveMapping.ContainsKey(CallerId))
            {
                //This assignment will update ExecutiveQ as well , as reference is used
                callExecutiveMapping[CallerId].WorkStatus = WorkStatus.Free;
            }
            else
                throw new Exception("Caller Id not found");
        }

        //Function assumes that Executive will found in ExecutiveQ for sure- Otherwise it will go to infinite loop
        public void UpdateExecutiveStatus(Executive Executive)
        {
            while (true)
            {
                var item = ExecutiveQ.Dequeue();
                if (item.EmployeeId == Executive.EmployeeId)
                {
                    item.WorkStatus = Executive.WorkStatus;
                    ExecutiveQ.Enqueue(item);
                    break;
                }
                else
                    ExecutiveQ.Enqueue(item);
            }
        }

    }
}
