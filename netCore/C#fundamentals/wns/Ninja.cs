using System;

namespace RPG
{
    public class Ninja : Human{
    public Ninja(string n) : base(n){
        dexterity = 175;
    }
    public void steal(object obj){
        health += 10;
        Human enemy = obj as Human;
        if(enemy != null){
            enemy.health -= 10;
        }
    }

    public void get_away()
        {  
            health -= 15;
        }
    }
}