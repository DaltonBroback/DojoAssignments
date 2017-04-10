using System;

namespace RPG
{
    public class Zombie : Enemy{
    public Zombie(string n) : base(n){
        health = 125;
        intelligence = 1;
        dexterity = 1;
    }
    public void bite(object obj){
        Human enemy = obj as Human;
        if(enemy != null){
                enemy.health -= 15;
            }
        }
    }
}