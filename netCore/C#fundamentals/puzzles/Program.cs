using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    public class Program
    {
        public static int[] RandomArray()
        {
            int[] array = new int[10];
            Random rnd = new Random();
            int min = int.MaxValue;
            int max = int.MinValue;
            int sum = 0;
            for(int i = 0; i<array.Length; i++)
                {
                    array[i] = rnd.Next(5,25);
                    if(array[i] < min){
                        min = array[i];
                    }
                    if(array[i] > max){
                        max = array[i];
                    }
                    sum += array[i];
                }
            Console.WriteLine("Min: "+min);
            Console.WriteLine("Max: "+max);
            Console.WriteLine("Sum: "+sum);
            return array;
        }
        public static string TossCoin(Random rnd){
            Console.WriteLine("Tossing a Coin!");
            // Random rnd = new Random();
            int marker = rnd.Next(0,2);
            Console.WriteLine(marker);
            string result = "";
            if(marker == 0){
                result = "Heads";
            }
            else{
                result = "Tails";
            }
            Console.WriteLine(result);
            return result;
        }
        public static Double TossMultipleCoins(int num){
            int headcount = 0;
            for(int i=0; i<num; i++){
                if(TossCoin(new Random()) == "Heads"){
                    headcount += 1;
                }
            }
            return (double)headcount/(double)num;
        }
        public static void Main(string[] args)
        {
            RandomArray();
            TossMultipleCoins(10);
        }
    }
}
