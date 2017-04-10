using System;

namespace RPG
{
    public class Spider : Enemy{
    public Spider(string n) : base(n){
        dexterity = 175;
    }
    public void drainblood(object obj){
        health += 10;
        Human enemy = obj as Human;
        if(enemy != null){
            enemy.health -= 10;
            }
        }
    }
}