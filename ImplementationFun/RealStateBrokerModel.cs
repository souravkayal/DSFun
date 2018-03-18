using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun.BrokerHouse
{
    //Broker can able to Register there firm
    //Broker can able  to keep entry listing
    //Broker can able to search entry
    //Broker can able to send SMS with recommendation

    #region Notification Section
        //Factory design pattern is used to send notification to user by SMS or Mail
    public interface INotification
    {
        void Send(Customer User);
    }

    public class SendSms : INotification
    {
        public void Send(Customer User)
        {
            //SMS Sending logic
        }
    }

    public class SendMail : INotification
    {
        public void Send(Customer User)
        {
            //Mail sending logic
        }
    }

    public class AlertNotifier
    {
        INotification Notifier;
        public AlertNotifier(INotification Obj)
        {
            this.Notifier = Obj;
        }
        public void SendNotification(Customer Customer)
        {
            this.Notifier.Send(Customer);
        }
    }
    #endregion

    public class BrokerFirm
    {
        public int Id { get; set; }
        public string FirmName { get; set; }
        public string RegBy { get; set; }
        public DateTime RegOn { get; set; }
        public Address Address { get; set; }
        public List<Customer> Customers { get; set; }

        //Partnership Concept
        public string PartnerCode { get; set; }
        public List<BrokerFirm> PartnersWith { get; set; }
    }
    public class Address
    {
        public string Street { get; set; }
        public string Location { get; set; }
    }
    public enum BHK
    {
        One,Two,Three
    }
    public enum PropertyType
    {
        IndividualHouse, Appartment, Studio , BuilderFloor
    }
    public class Specification
    {
        public BHK BHK { get; set; }
        public List<Address> ExpectedLocation { get; set; }
        public int StartPrice { get; set; }
        public int EndPrice { get; set; }
        public int SqftArea { get; set; }
        public PropertyType PropertyType { get; set; }
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public Specification Requirement { get; set; }
    }

    public class RealBroker
    {
        public List<BrokerFirm> Brokers;
        AlertNotifier Notifier;

        public RealBroker()
        {
           this.Brokers = new List<BrokerFirm>();
           this.Notifier = new AlertNotifier(new SendSms()); // TODO : Resolve dependency by injection
        }
        public void RegisterFirm(BrokerFirm Firm)
        {
            this.Brokers.Add(Firm);
        }
        public void AddCustomerRequirement(int FirmId, Customer Customer)
        {
            var broker = this.Brokers.Where(f => f.Id == FirmId).FirstOrDefault();
            if(broker != null)
            {
                broker.Customers.Add(Customer);
            }
        }
        public List<Customer> SearchCustomerByRequirement(int FirmId, Specification Where)
        {
            var Item = this.Brokers.Where(f => f.Id == FirmId).FirstOrDefault();
            if(Item != null)
            {
                return Item.Customers.Where(f => f.Requirement.BHK == Where.BHK || (f.Requirement.StartPrice == Where.StartPrice && f.Requirement.EndPrice == Where.EndPrice)).ToList();
            }
            return null;
        }
        public List<Customer> SearchByWhere(int FirmId, Func<Customer,bool> Where)
        {
            return this.Brokers.Where(f => f.Id == FirmId).First().Customers.Where(Where).ToList();
        }
        public void NotifyUser(Customer Customer)
        {
            this.Notifier.SendNotification(Customer);
        }

        //TODO : Add partner functionality is missing 
        //Function to Search specification in partner's customer list by partner's code
        public List<Customer> SearchSpecificationInPartner(int FirmId, List<string> PartnerCodes , Specification Specification)
        {
            List<Customer> Result = new List<Customer>();

            var Partners = this.Brokers.Where(f => f.Id == FirmId).First().PartnersWith;
            if(Partners !=  null && Partners.Count > 0)
            {
                foreach (var item in PartnerCodes)
                {
                    var Data = Partners.Where(f => f.PartnerCode == item).First().
                                Customers.Where(f => f.Requirement.BHK == Specification.BHK && (f.Requirement.StartPrice == Specification.StartPrice && f.Requirement.EndPrice == Specification.EndPrice)).ToList();
                    Result.AddRange(Data);
                }
            }
            return Result;
        }

    }
}
