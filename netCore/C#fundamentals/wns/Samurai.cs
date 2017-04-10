using System;
using System.Threading;

namespace RPG
{
    public class Samurai : Human{
    
    static int SamuraiCounter = 0;
    public Samurai(string n) : base(n){
        health = 200;
        Interlocked.Increment(ref SamuraiCounter);
    }
    public void death_blow(object obj){
        Human enemy = obj as Human;
        if(enemy == null || enemy.health > 50)
        {
            System.Console.WriteLine("Failed Attack");
        }
        else
        {
            enemy.health = 0;
        }
    }

    public void meditate()
        {  
            health = 200;
        }
    public void how_many()
        {
            System.Console.WriteLine("Number of Samurai: "+SamuraiCounter);
        }
    }
}