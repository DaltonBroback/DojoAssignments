using System;

namespace RPG
{
    public class Program
    {
        public static void displayHeroes(Human[] party)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Party");
            int i = 1;
            foreach(Human hero in party){
                if(hero.health < 0){
                    continue;
                }
                System.Console.WriteLine(i + " "+hero.name+" - HP: "+hero.health);
                i++; 
            }
        }

        public static void displayEnemies(Enemy[] foes)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Enemies:");
            int i = 1;
            foreach(Enemy foe in foes){
                if(foe.health < 0){
                    continue;
                }
                System.Console.WriteLine(i + " "+foe.name+" - HP: "+foe.health);
                i++; 
            }
        }

        public static void displayActions(Human hero)
        {
            int i = 1;
            foreach(String action in actions){
                System.Console.WriteLine(i + " "+action);
                i++; 
            }
        }
        public static void Main(string[] args)
        {
            Wizard wiz = new Wizard("Gandalf");
            Ninja nin = new Ninja("Sheena");
            Samurai sam = new Samurai("Jack");
            Zombie zom1 = new Zombie("Zombie 1");
            Zombie zom2 = new Zombie("Zombie 2");
            Spider spid1 = new Spider("Spider");

            object[] turnorder = new object[]{wiz,nin,sam,zom1,zom2,spid1};
            Enemy[] foes = new Enemy[]{zom1,zom2,spid1};
            Human[] party = new Human[]{wiz,nin,sam};

            bool gameloop = true;
            System.Console.WriteLine("Enemies appear!");
            displayEnemies(foes);
            displayHeroes(party);
            while(gameloop == true){
                System.Console.WriteLine("Party's Turn!");

                if(wiz.health > 0){
                    System.Console.WriteLine(wiz.name+"'s turn!");
                    System.Console.WriteLine("Actions:");
                    System.Console.WriteLine("1 Basic Attack");
                    System.Console.WriteLine("2 Heal");
                    System.Console.WriteLine("3 Fireball");
                    string res = Console.ReadLine();
                    switch(res){
                        case "1":
                            System.Console.WriteLine("Choose Your Target");
                            displayEnemies(foes);
                            break;
                        default:
                            {
                                System.Console.WriteLine("Invalid Command!");
                                break;
                            }

                    }
                }
            }
        }
    }
}
