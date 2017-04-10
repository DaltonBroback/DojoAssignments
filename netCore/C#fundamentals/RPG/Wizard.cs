using System;

namespace RPG
{
    public class Wizard : Human{
    public Wizard(string n) : base(n){
        health = 50;
        intelligence = 25;
        string[] actions = {"Attack","Heal","Fireball"};

    }
    public void heal(){
        System.Console.WriteLine(name+" healed "+(intelligence * 10)+" HP.");
        health += (intelligence * 10);
    }

    public void fireball(object obj)
        {  
            Random rnd = new Random();
            int damage = rnd.Next(20,51);
            Enemy enemy = obj as Enemy;
            if(enemy == null)
            {
                Console.WriteLine("Failed Attack");
            }
            else
            {
                System.Console.WriteLine(name + " attacks "+enemy.name);
                enemy.health -= damage;
                System.Console.WriteLine(enemy.name+" took "+damage+" damage");
            }
        }
    }
}