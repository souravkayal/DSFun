using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun.AuxionSystem
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desciprtion { get; set; }
        public int BasePrice { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserBid
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int Bid { get; set; }
    }

    public class AuxionSystem
    {
        List<Item> Item = new List<Item>();
        Dictionary<Item, Stack<UserBid>> ItemBid = new Dictionary<Item, Stack<UserBid>>();

        public void AddItemForBid(Item Item)
        {
            var adminUser = new User { Id = 99, Name = "Admin" };
            Stack<UserBid> Stk = new Stack<UserBid>();
            Stk.Push(new UserBid { User = adminUser, Bid = 100, Id = 1 });
            ItemBid.Add(Item, Stk);
        }

        public void AddBid(Item Item, UserBid Bid)
        {
            var itemStack = ItemBid[Item];
            if (itemStack.Peek().Bid > Bid.Bid)
            {
                itemStack.Push(Bid);
            }
            else
                throw new Exception("Invalid Bid");
        }
        
        public List<UserBid> GetAllBidByItem(Item Item)
        {
            return ItemBid[Item].ToList();
        }

    }
}
