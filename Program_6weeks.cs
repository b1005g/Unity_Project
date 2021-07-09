//override 와 sealed 한정자를 이용한 메소드 선언방법 프로그래밍
using System;

namespace ConsoleApp_6weeks
{
    class Helloworld
    {
        static void Main(string[] args)
        { 

        }
    }
    class Base
    {
        public virtual void BasePrint()
        {
            Console.WriteLine("부모클래스 입니다.");
        }
        public virtual void Seal()
        {
            Console.WriteLine("부모클래스 입니다.");
        }
    }

    class Derived : Base
    {
        public override void BasePrint()
        {
            base.BasePrint();
            Console.WriteLine("자식클래스 입니다.");
        }
        public sealed override void Seal()
        {
            Console.WriteLine("함수를 봉인합니다.");
        }
    }
}
