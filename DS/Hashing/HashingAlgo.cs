using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Hashing
{
    //table RSVP
    //Name, Decision, Date
    //Jon, Y, 1 jan 2016 
    //Jon, N, 2 Jan 2016 
    //Linda, Y, 1 Jan 2016 
    //Mark, Y, 5 Jan 2016 
    //Rob, N, 5 Jan 2016 

    public class DecessionChoice
    {
        public class People
        {
            public string Name { get; set; }
            public bool Status { get; set; }
            public DateTime DateReplyed { get; set; }
        }
        public void ProcessResponse(List<People> List)
        {
            Dictionary<string, People> Disc = new Dictionary<string, People>();

            foreach (var item in List)
            {
                if(!Disc.ContainsKey(item.Name))
                {
                    Disc.Add(item.Name, item);
                }
                else
                {
                    var people = Disc[item.Name];
                    if(item.DateReplyed > people.DateReplyed)
                    {
                        people.Status = item.Status;
                    }
                }
            }

            foreach (var item in Disc.Values)
            {
                Console.WriteLine("Name:" + item.Name + ":" + item.Status);
            }
        }
    }
}
