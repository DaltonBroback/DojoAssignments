using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Number1(){
            for(int i = 1;i<256;i++){
                Console.WriteLine(i);
            }
        }
        public static void Number2(){
            for(int i = 1;i<256;i++){
                if (i%2 != 0){
                    Console.WriteLine(i);
                }
            }
        }
        public static void Number3(){
            int sum = 0;
            for(int i = 0;i<256;i++){
                sum += i;
                Console.WriteLine("New Number: "+i+" Sum: "+sum);
            }
        }
        public static void Number4(int[] X){
            foreach(var item in X)
            {
                Console.WriteLine(item);
            }
        }
        public static void Number5(int[] X){
            int max = X[0];
            foreach(var item in X)
            {
                if(item>max){
                    max = item;
                }
            }
        Console.WriteLine(max);
        }
        public static void Number6(int[] X){
            int sum = 0;
            foreach(var item in X)
            {
                sum += item;
            }
            int avg = sum / X.Length;
            Console.WriteLine(avg);
        }
        public static int[] Number7(){
            List<int> y = new List<int>();
            for(int i = 1;i<256;i++){
                if (i%2 != 0){
                    y.Add(i);
                }
            }
            return y.ToArray();
        }
        public static int[] Number8(int[] arr, int y){
            List<int> greater = new List<int>();
            for(int i = 0;i<arr.Length;i++){
                if (arr[i] > y){
                    greater.Add(arr[i]);
                }
            }
            return greater.ToArray();
        }
        public static void Number9(int [] x){
            for(int i = 0;i<x.Length;i++){
                x[i] = x[i]*x[i];
            }
        }
        public static void Number10(int [] x){
            for(int i = 0;i<x.Length;i++){
                if (x[i] < 0){
                    x[i] = 0;
                }
            }
        }
        public static void Number11(int [] x){
            int max = x[0];
            int min = x[0];
            int sum = 0;
            int avg = 0;
            for(int i = 0;i<x.Length;i++){
                if (x[i] < min){
                    min = x[i];
                }
                if (x[i] > max){
                    max = x[i];
                }
                sum += x[i];
            }
            avg = sum/x.Length;
            Console.WriteLine("Max: "+max);
            Console.WriteLine("Min: "+min);
            Console.WriteLine("Average: "+avg);
        }
        public static void Number12(int [] x){
            for(int i = 0;i<x.Length-1;i++){
                x[i] = x[i+1];
                }
            x[x.Length-1]=0;
        }
        public static void Number13(object [] x){
            for(int i = 0;i<x.Length;i++){
                if ((int)x[i] < 0){
                    x[i] = "Dojo";
                }
            }
        }


        public static void Main(string[] args)
        {
            Console.WriteLine("1) Print 1-255");
            Number1();
            Console.WriteLine("2) Print odd numbers between 1-255");
            Number2();
            Console.WriteLine("3) Print Sum");
            Number3();
            int[] X = {1,3,5,7,9,13};
            Console.WriteLine("4) Iterating through an Array");
            Number4(X);
            int[] Y = {-3,-5,-7};
            Console.WriteLine("5) Find Max");
            Number5(Y);
            int[] Z = {2,10,3};
            Console.WriteLine("6) Get Average");
            Number6(Z);
            Console.WriteLine("7) Array with Odd Numbers");
            int[] y = Number7();
            for(int i=0;i<y.Length;i++)
                {
                    Console.WriteLine(y[i]);
                }
            Console.WriteLine("8) Greater than Y");
            int [] arr = {1, 3, 5, 7};
            int q = 3;
            int[] greater = Number8(arr, q);
            for(int i=0;i<greater.Length;i++)
                {
                    Console.WriteLine(greater[i]);
                }
            int [] x = {1,5,10,-2};
            Console.WriteLine("9) Square the Values");
            Number9(x);
            for(int i=0;i<x.Length;i++)
                {
                    Console.WriteLine(x[i]);
                }
            Console.WriteLine("10) Eliminate Negative Numbers");
            int [] xtochange = {1,5,10,-2};
            Number10(xtochange);
            for(int i=0;i<xtochange.Length;i++)
                {
                    Console.WriteLine(xtochange[i]);
                }
            Console.WriteLine("11) Min, Max, and Average");
            int [] z = {1,5,10,-2};
            Number11(z);
            Console.WriteLine("12) Shifting Values in Array");
            int [] a = {1,5,10,7,-2};
            Number12(a);
            for(int i=0;i<a.Length;i++)
                {
                    Console.WriteLine(a[i]);
                }
            Console.WriteLine("13) Number to String");
            object [] b = {-1,-3,2};
            Number13(b);
            for(int i=0;i<b.Length;i++)
                {
                    Console.WriteLine(b[i]);
                }
        }
    }
}
