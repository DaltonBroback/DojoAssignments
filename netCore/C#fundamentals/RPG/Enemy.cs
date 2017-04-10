using System;

namespace RPG
{
    public class Enemy
    {
        public string name;

        //The { get; set; } format creates accessor methods for the field specified
        //This is done to allow flexibility
        public int health { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }

        public Enemy(string monster)
        {
            name = monster;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
        }
        public Enemy(string monster, int str, int intel, int dex, int hp)
        {
            name = monster;
            strength = str;
            intelligence = intel;
            dexterity = dex;
            health = hp;
        }
        public void attack(object obj)
        {
            Human target = obj as Human;
            if(target == null)
            {
                Console.WriteLine("Enemy Attack Failed");
            }
            else
            {
                target.health -= strength * 5;
            }
        }
        public void die(){
            if(health<0){
                System.Console.WriteLine(name+"was killed!");
            }
        }
    }
 
}