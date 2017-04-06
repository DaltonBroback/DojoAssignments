using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numArray = {1,2,3,4,5,6,7,8,9};
            string[] Names = {"Tim","Martin","Nikki","Sara"};
            bool[] boolArray = new bool[10];
            bool marker = false;
            for(int idx = 0; idx < boolArray.Length; idx++)
            {
                if(marker == false){
                    marker = true;
                }
                else{
                    marker = false;
                }
                boolArray[idx] = marker;
            }  
            int [,] multiArray = new int[10,10];
            for(int idx = 0; idx<10; idx ++)
            {
                for(int i = 0; i<10; i ++)
                {
                    multiArray[idx,i] = (idx+1)*(i+1);
                }
            }

            List<string>IceCream = new List<string>();
            IceCream.Add("Vanilla");
            IceCream.Add("Chocolate");
            IceCream.Add("Strawberry");
            IceCream.Add("Sherbet");
            IceCream.Add("Mint");
            Console.WriteLine(IceCream.Count);
            Console.WriteLine(IceCream[2]);
            IceCream.RemoveAt(2);
            Console.WriteLine(IceCream.Count);

            Random rnd = new Random();
            Dictionary<string,string> profile = new Dictionary<string,string>();
            foreach(var item in Names)
            {
                string name = item;
                int flavoridx = rnd.Next(0,5);
                string flavor = IceCream[flavoridx];
                profile.Add(name, flavor);
                Console.WriteLine(name + ": " + profile[name]);
            }
        }
    }
}
