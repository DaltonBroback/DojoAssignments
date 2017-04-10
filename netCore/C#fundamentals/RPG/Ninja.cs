using System;

namespace RPG
{
    public class Ninja : Human{
    public Ninja(string n) : base(n){
        dexterity = 175;
        string[] actions = {"Attack","Steal","Get Away"};
    }
    public void steal(object obj){
        health += 10;
        Enemy enemy = obj as Enemy;
        if(enemy != null){
            System.Console.WriteLine(name + " attacks "+enemy.name);
            enemy.health -= 10;
            System.Console.WriteLine(enemy.name+" took "+(strength * 5)+" damage");
        }
    }

    public void get_away()
        {  
            health -= 15;
        }
    }
}