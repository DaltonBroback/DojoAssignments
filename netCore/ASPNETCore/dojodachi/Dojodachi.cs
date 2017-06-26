using System;

namespace dojodachi
{
    public class Dojodachi
    {
        public int happiness { get; set; }
        public int fullness { get; set; }
        public int energy { get; set; }
        public int meals { get; set; }
        public Dojodachi()
        {
            happiness = 20;
            fullness = 20;
            energy = 50;
            meals = 3;
        }
        public string feed()
        {
            string result;
            meals -= 1;
            Random rnd = new Random();
            if(rnd.Next(0,4) > 0)
                {
                    int food = rnd.Next(5,11);
                    fullness += food;
                    result = "You fed your Dojodachi! Fullness +"+food+", Meals -1";
                }
            else
            {
                result = "Your Dojodachi didn't like that meal... Meals -1";
            }
            return result;
        }
        public string play()
        {
            string result;
            energy -= 5;
            Random rnd = new Random();
            if(rnd.Next(0,4) > 0)
                {
                    int fun = rnd.Next(5,11);
                    happiness += fun; 
                    result = "You played with your Dojodachi! Happiness +"+fun+", Energy -5";
                }
            else{
                result = "Your Dojodachi doesn't like this game. Energy -5";
            }
            return result;
        }
        public string work()
        {
            string result;
            energy -= 5;
            Random rnd = new Random();
            int groceries = rnd.Next(1,4);
            meals += groceries;
            result = "You got in a good day of work. Meals +"+groceries+", Energy -5";
            return result;
        }
        public string sleep()
        {
            energy += 15;
            fullness -= 5;
            happiness -= 5;
            string result = "Your Dojodachi got a good night's sleep. Energy +15, Fullness -5, Happiness -5";
            return result;
        }
    }
 
}