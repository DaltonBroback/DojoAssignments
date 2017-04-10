using System;
using System.Threading;

namespace RPG
{
    public class Samurai : Human{
    
    static int SamuraiCounter = 0;
    public Samurai(string n) : base(n){
        health = 200;
        Interlocked.Increment(ref SamuraiCounter);
        string[] actions = {"Attack","Death Blow","Medidate"};
    }
    public void death_blow(object obj){
        Enemy enemy = obj as Enemy;
        if(enemy == null || enemy.health > 50)
        {
            System.Console.WriteLine("Failed Attack");
        }
        else
        {
            System.Console.WriteLine(enemy.name+" was killed in a single blow!");
            enemy.health = 0;
        }
    }

    public void meditate()
        {  
            System.Console.WriteLine(name+" was fully healed.");
            health = 200;
        }
    public void how_many()
        {
            System.Console.WriteLine("Number of Samurai: "+SamuraiCounter);
        }
    }
}