using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun
{

    public class Block
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Data { get; set; }
        public string Hash { get; set; }
    }

    /// <summary>
    /// Block Chain is a technology to represent a set of blocks in chain. There each block represents a unit of transaction
    /// Each block holds hash of it's previous block.
    /// </summary>
    public class BlockChain
    {
        List<Block> BlockChains = new List<Block>();

        public BlockChain(int Id, string Data)
        {
            var InitialBlock = new Block { Id = Id, Data = Data , CreatedAt = DateTime.Now };
            BlockChains.Add(InitialBlock);
        }

        public Block ReturnLastBlock()
        {
            return BlockChains[BlockChains.Count - 1];
        }

        public string GetHash(Block Item)
        {
            return (Item.Data.GetHashCode() + Item.CreatedAt.GetHashCode()).ToString();
        }

        public void AddBlock(int Id, string Data)
        {
            BlockChains.Add(new Block { Id = Id, Data = Data, CreatedAt = DateTime.Now, Hash = GetHash(ReturnLastBlock())});
        }

        public void PrintChain()
        {
            foreach (var item in BlockChains)
            {
                Console.WriteLine(item.Id + ":" + item.Data);
            }
        }

        public bool ValidateChain()
        {
            for (int i = 1 ; i < BlockChains.Count-1; i++)
            {
                if (BlockChains[i].Hash != GetHash(BlockChains[i - 1]))
                {
                    return false;
                }
            }
            return true;
        }



    }
}
