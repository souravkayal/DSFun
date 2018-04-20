using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun
{
    public class Scientist
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class BlackHole
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Query
    {
        public BlackHole BlackHole { get; set; }
        public QueryType QueryType { get; set; }
    }
    public enum QueryType
    {
        Redioud, Tempuratore
    }

    public class BlackHoleOperation
    {
        Dictionary<Scientist, Queue<Query>> QueryList = new Dictionary<Scientist, Queue<Query>>();

        public void AddQuery(Scientist Sc, Query Query)
        {
            if(QueryList.ContainsKey(Sc))
            {
                QueryList[Sc].Enqueue(Query);
            }
        }

        public List<Query> FindAllQueryByScientist(Scientist Sc)
        {
            return QueryList[Sc].ToList();
        }
    }


}
