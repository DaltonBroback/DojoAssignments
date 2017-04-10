using System;

namespace RPG
{
    public class Wizard : Human{
    public Wizard(string n) : base(n){
        health = 50;
        intelligence = 25;
    }
    public void heal(){
        health += intelligence * 10;
    }

    public void fireball(object obj)
        {  
            Random rnd = new Random();
            int damage = rnd.Next(20,51);
            Human enemy = obj as Human;
            if(enemy == null)
            {
                Console.WriteLine("Failed Attack");
            }
            else
            {
                enemy.health -= damage;
            }
        }
    }
}