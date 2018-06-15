using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun.DesignPattern
{
    #region Composit Design Pattern
    public class PersonalInfo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class Address
    {
        public string AddressDetail { get; set; }
    }

    public class PersonInfo
    {
        public PersonalInfo Personal { get; set; }
        public Address Address { get; set; }
    }

    #endregion


}
