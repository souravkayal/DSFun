using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun.SnakeAndLadder
{

    /// <summary>
    /// Implementation of Chess and Board Game.
    /// </summary>
    public class Board
    {
        public int [,]ChBoard;
        public Dictionary<int, int> Ladder = new Dictionary<int, int>();
        public Dictionary<int, int> Snake = new Dictionary<int, int>();

        // Load position of Snake and Ladder in Board. There are mutually exclusive
        public Board()
        {
            Ladder.Add(5, 15);
            Ladder.Add(9, 20);

            Snake.Add(29, 7);
            Snake.Add(25, 1);
        }
    }

    public class User
    {
        public string Name { get; set; }
        public int Position { get; set; }
    }

    public class SnakeAndLadder
    {
        List<User> Users = new List<User>();
        Board Board = new Board();

        public SnakeAndLadder(List<User> users)
        {
            Users = users;
        }

        public void Play(User user, int Value)
        {
            if (user.Position + Value == 100)
                Console.WriteLine(user.Name + "Win");
            else
            {
                //Both Snake and Ladder are mutualy exclusive
                //it's in ladder
                if (Board.Ladder.ContainsKey(user.Position + Value))
                {
                    user.Position = Board.Ladder[user.Position + Value];
                }
                //Check in snake
                if (Board.Snake.ContainsKey(user.Position + Value))
                {
                    //it's in ladder
                    user.Position = Board.Ladder[user.Position + Value];
                }
            }
        }

        public int GetRandom()
        {
            return new Random().Next(1, 6);
        }
    }
}
