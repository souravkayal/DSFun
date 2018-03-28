using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun
{
    public class Quote
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
    //The problem is to return random items in constant time. Once we return the item , we cannot able to return it anymore.
    //In case of implementation where there is no list, then aux list need to use to keep track of eleted items and return 
    //random number from only available numbers
    public class ReturnRandomItemInConstantTime
    {
        List<Quote> Quotes = new List<Quote>();
        static Random Rnd = new Random(); 

        public void LoadQuotes()
        {
            for (int i = 0; i < 10; i++)
            {
                Quotes.Add(new Quote { Id = i, Value = "Item" + i });
            }
        }

        public Quote ReturnRandomQuote()
        {
            var Index = Rnd.Next(0, Quotes.Count);
            var Quote = Quotes[Index];
            Quotes.RemoveAt(Index);

            return Quote;
        }


    }
}
