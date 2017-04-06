using System;
using System.Collections.Generic;


namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<object> data = new List<object>();
            data.Add(7);
            data.Add(28);
            data.Add(-1);
            data.Add(true);
            data.Add("chair");
            foreach(var item in data){
                Console.WriteLine(item);
            }
            int sum = 0;
            foreach(var item in data){
                if(item is int){
                    sum += (int)item;
                }
            }
            Console.WriteLine("Sum: "+sum);


        }
    }
}
