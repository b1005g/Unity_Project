using System;

namespace ConsoleApp_midterm
{
    
    
    class Helloworld
    {
        static void Main(string[] args)
        {
            int total = 0;
            int i = 0;
            do
            {
                i = i +1;
                Console.WriteLine(i);

                if (i % 2 == 0)
                {
                    total = total + i;
                }
                Console.WriteLine(total);
            }
            while (i < 20 );
            
        }
    }
}
