using System;

namespace RPG
{
    public class Human
    {
        public string name;

        //The { get; set; } format creates accessor methods for the field specified
        //This is done to allow flexibility
        public int health { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }

        string[] actions {get; set; }
        public Human(string person)
        {
            name = person;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
            actions = new string[] {"Attack"};
        }
        public Human(string person, int str, int intel, int dex, int hp)
        {
            name = person;
            strength = str;
            intelligence = intel;
            dexterity = dex;
            health = hp;
        }
        public void attack(object obj)
        {
            Enemy enemy = obj as Enemy;
            if(enemy == null)
            {
                Console.WriteLine("Failed Attack");
            }
            else
            {
                System.Console.WriteLine(name + " attacks "+enemy.name);
                enemy.health -= strength * 5;
                System.Console.WriteLine(enemy.name+" took "+(strength * 5)+" damage");
            }
        }
        public void die(){
            if(health < 0){
                System.Console.WriteLine(name+"was killed!");
            }
        }
    }
 
}