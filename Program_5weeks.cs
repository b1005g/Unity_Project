
using System;
// Swap()함수 - ref를 이용해서 데이터값 변경하는 예제

namespace ConsoleApp_5weeks
{
    class Program
    {
        public static void Plus(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;
            PrintProfile(name: "박찬호", phone: "010-1234-1234");
        }
        static void Main(string[] args)
        {
            int x = 10;
            int y = 15;
            Program.Plus(ref x, ref y);
            Console.WriteLine(x);
            Console.WriteLine(y);
            Cat kitty1 = new Cat();
            kitty1.a = 10;

            Cat kitty2 = new Cat();
            kitty2.a = kitty1.a;

            kitty2.a = 20;
            Console.WriteLine(kitty1.a);
        }

        static void Divide(int a, int b, out int quo, out int rem)
        {
            quo = a / b;
            rem = a % b;
            
        }
        static void PrintProfile( string name, string phone)
        {
            Console.WriteLine("Name:{0}, Phone:{1}", name, phone);
        }
        class Cat
        {
            public int a;
        }

        
    }
}


    

