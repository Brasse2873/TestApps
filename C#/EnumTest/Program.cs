using System;

namespace EnumTest
{
    public enum MyIntEnum
    {
        NoMonth = 0,
        January = 1,
        February = 2
    }

    public enum MyCharEnum : byte
    {
        NoOperation     = (byte)' ',
        Addition        = (byte)'+',
        Subtraction     = (byte)'-'
    }

    class Program
    {
        static void Main(string[] args)
        {

            MyIntEnum month = MyIntEnum.January;
            Console.WriteLine( "month.ToString=" + month.ToString() );


            MyCharEnum oper = MyCharEnum.Addition;
            Console.WriteLine("oper=" + oper);
            Console.WriteLine("oper.ToString=" + oper.ToString() );
            Console.WriteLine("oper.ToString(D)=" + oper.ToString("D"));
            Console.WriteLine("ToChar=" + Convert.ToChar( Convert.ToInt32( oper.ToString("D") )));
        }
    }
}
