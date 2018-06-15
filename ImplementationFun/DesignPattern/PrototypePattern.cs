using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun.DesignPattern
{
    /// <summary>
    /// The main Goal to implement prototype pattern is to create prototype Object
    /// </summary>

    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }

        public Person()
        {
            Address = "Default Address";
        }

        public Person(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        //Memberwise Clone
        public Person GetObject()
        {
            return (Person) this.MemberwiseClone();
        }
    }
}
