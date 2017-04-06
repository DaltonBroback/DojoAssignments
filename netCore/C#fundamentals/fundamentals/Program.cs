using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            for(int i = 1; i<256; i++)
            {
                Console.WriteLine(i);
            }        
            for(int i = 1; i<101; i++)
            {
                if(i%3 == 0 && i%5!= 0)
                {
                    Console.WriteLine("Fizz");
                }
                if(i%5 == 0 && i%3!= 0)
                {
                    Console.WriteLine("Buzz");
                }
                if(i%5 == 0 && i%3 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
            }
            int five = 5;
            int three = 3;
            for(int i = 1; i<101; i++)
            {
                five --;
                three --;
                if (five == 0 && three == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (three == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (five == 0)
                {
                    Console.WriteLine("Buzz");
                }
            
            }
        Random rnd = new Random();
        for(int i = 1; i<11; i++){
            int totest = rnd.Next(1,100);
            if(totest%3 == 0 && totest%5!= 0)
            {
                Console.WriteLine("Fizz");
            }
            if(totest%5 == 0 && totest%3!= 0)
            {
                Console.WriteLine("Buzz");
            }
            if(totest%5 == 0 && totest%3 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }            
        }
        }
    }
}
