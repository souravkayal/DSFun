using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun.PhoneCallLog
{
    /// <summary>
    /// Implementation of data model of phone call operation
    /// </summary>
    
    public enum CallType
    {
        Incomming, Outgoing, Missed
    }
    public class Call
    {
        public int Id { get; set; }
        public CallType CallType { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Duration { get; set; }
        public DateTime CallAt { get; set; }
    }
    public class PhoneCallLog
    {
        List<Call> AllCalls;
        public PhoneCallLog()
        {
            this.AllCalls = new List<Call>();
        }

        public List<Call> GetCallBy(Func<Call,bool> where)
        {
            return this.AllCalls.Where(where).ToList();
        }

        public void AddCall(Call Item)
        {
            this.AddCall(Item);
        }

        public void RemoveCall(int Id)
        {
            this.AllCalls.Remove(AllCalls.Where(f => f.Id == Id).First());
        }


    }
}
