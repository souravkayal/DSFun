using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun.ProductCatalogue
{
    //nodeid    parentid    Nodename
    //10        1           Commedy Book
    //20        2           Tablets
    //1         -1          Books
    //11        1           Novels
    //12        11          Terror Novel
    //2         -1          Electronics
    //-1        0           GlobalRoot
    
    public class Category
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string NodeName { get; set; }

        public List<Category> Childrens { get; set; }

        public Category()
        {
            this.Childrens = new List<Category>();
        }
    }

    public class CatTree
    {
        public Category Root { get; set; }
        //Id and Item
        Dictionary<int, Category> Cat = new Dictionary<int, Category>();

        public CatTree(Category Root)
        {
            this.Root = Root;
        }

        public void AddAllCategory(List<Category> List)
        {
            foreach (var item in List)
            {
                Cat.Add(item.Id, item);
            }
        }

        public List<Category> GetChildrenByCatId(int Id)
        {
            List<Category> List = new List<Category>();
            foreach (var item in Cat)
            {
                if (item.Value.ParentId == Id)
                    List.Add(item.Value);
            }
            return List;
        }

        public void BuildTree(Category Root)
        {
            if (Cat.Count == 0)
                return;
            else 
            {
                int Id = Root.Id;
                var childrens = GetChildrenByCatId(Id);
                Root.Childrens.AddRange(childrens);

                var items = Cat.Where(f => f.Value.ParentId == Id).ToList();
                foreach (var item in items)
                {
                    Cat.Remove(item.Key);
                }

                foreach (var item in childrens)
                {
                    BuildTree(item);
                }
            }
        }

    }
    
}
