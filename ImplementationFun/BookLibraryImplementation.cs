using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun
{

    //People can able to take membership
    //Three type of membership is available
    //There will be rule for different membership. and the borrow date is based on membership

    public enum MembershipType
    {
        Bronch, Silver, Gold
    }

    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MembershipType MemberType { get; set; }
        public DateTime JoiningDate { get; set; }
        public List<Book> Book { get; set; }
    }

    public enum BookType
    {
        Book, Megazine, Other
    }
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
    }
    
}
