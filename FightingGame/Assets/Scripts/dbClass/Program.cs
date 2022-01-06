using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect2SQL3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List of Heroes:-");
            
            //get and display list of hero
            string[] HeroList = getList.getHero();
            foreach(string Hero in HeroList)
            {
                Console.WriteLine(Hero);
            }
            Console.WriteLine();
            
            //Player Choose hero
            Console.WriteLine("Player 1");
            string Player1Choice = enterPlayer(HeroList);

            Console.WriteLine("Player 2");
            string Player2Choice = enterPlayer(HeroList);

            Console.WriteLine();

            Person Player1 = new Person(Player1Choice);
            Person Player2 = new Person(Player2Choice);
            Person Minion = new Person("Minion");


            //Display Hero
            Console.WriteLine("Player 1");
            Player1.ShowState();
            Console.WriteLine();
            Console.WriteLine("Player 2");
            Player2.ShowState();
            Console.WriteLine();
            Console.WriteLine("Fight your minion!!");
            Console.WriteLine("Minion State");
            Minion.ShowState();
            Console.WriteLine();


            Console.ReadLine();
        }

        static string enterPlayer(string[] HeroList)
        {
            while(true)
            {
                Console.WriteLine("Please enter your hero:");
                string getHero = Console.ReadLine();
                if (String.IsNullOrEmpty(getHero))
                {
                    Console.WriteLine("You have not enter a hero");
                    continue;
                }
                else
                {
                    getHero = getHero.ToLower();
                    getHero = getHero.First().ToString().ToUpper() + getHero.Substring(1);
                }

                foreach(string hero in HeroList)
                {
                    if(hero == getHero)
                    {
                        return hero;
                    }
                }
                Console.WriteLine(getHero + " is not a valid hero.");
            }
            
        }
    }
}
