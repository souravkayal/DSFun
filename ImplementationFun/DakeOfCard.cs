using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun
{
    public enum CardType
    {
        Ace, Club, Spread, Heart
    }

    public enum CardNumber
    {
        One =1, Two, Three, Four, Five, Six, Seven,Eight, Nine, Ten, Jack, Queen, King 
    }

    public class Card
    {
        public CardNumber CardNumber { get; set; }
        public CardType CardType { get; set; }
    }

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Card> Hand { get; set; }
    }

    public class DakeOfCard
    {
        List<Card> Cards = new List<Card>();
        Queue<Player> Players = new Queue<Player>();

        static Random rnd = new Random();

        public DakeOfCard()
        {
            for (int i = 1; i <= 13; i++)
            {
                Cards.Add(new Card { CardNumber = (CardNumber)i , CardType = CardType.Ace});
                Cards.Add(new Card { CardNumber = (CardNumber)i, CardType = CardType.Club });
                Cards.Add(new Card { CardNumber = (CardNumber)i, CardType = CardType.Heart });
                Cards.Add(new Card { CardNumber = (CardNumber)i, CardType = CardType.Spread });
            }
        }

        public void Suffle()
        {
            for (int i = 0; i < 25; i++)
            {
                int rnd1 = rnd.Next(51);
                int rnd2 = rnd.Next(51);

                Card tmp = Cards[rnd1];
                Cards[rnd1] = Cards[rnd2];
                Cards[rnd2] = tmp;
            }
        }

        public void PrintAllCards()
        {
            foreach (var item in Cards)
            {
                Console.WriteLine(item.CardType + ":" + item.CardNumber);
            }
        }

        void AddPlayer()
        {
            Players.Enqueue(new Player { Id = 1, Name = "A" , Hand = new List<Card>()});
            Players.Enqueue(new Player { Id = 2, Name = "B" , Hand = new List<Card>() });
            Players.Enqueue(new Player { Id = 3, Name = "C" , Hand = new List<Card>() });
            Players.Enqueue(new Player { Id = 4, Name = "D" , Hand = new List<Card>() });
        }

        public void DistributeAllHands()
        {
            if(Players.Count ==0)
            {
                AddPlayer();
            }
            foreach (var Card in Cards)
            {
                var player = Players.Dequeue();
                player.Hand.Add(Card);
                Players.Enqueue(player);
            }
        }

        public void PrintAllHands()
        {
            int Count = 0;
            while (Count < 4)
            {
                var item = Players.Dequeue();
                Console.WriteLine("----" + item.Name + "---");
                foreach (var Card in item.Hand)
                {
                    Console.WriteLine(Card.CardNumber + ":" + Card.CardType);
                }
                ++Count;
            }
            
        }
    }



}
