    namespace ConsoleApplication{
        public class Human
        {
            public string name;
            public int strength = 3;
            public int intelligence = 3;
            public int dexterity = 3;
            public int health = 100;
            public Human(string name)
            {
            }
            public Human(int strength, int intelligence, int dexterity, int health, string name)
            {
            }
            
            public void Attack(object target)
            {
                if(target is Human){
                    Human victim = target as Human;
                    victim.health -= (strength*5);
                }
            }
        }
    }