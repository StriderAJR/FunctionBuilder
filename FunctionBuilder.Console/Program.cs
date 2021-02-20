namespace FunctionBuilder.Console
{
    using FunctionBuilder.Logic;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var func = new Function("(1/2+0.5)+2*(4-1/2)");
            Console.WriteLine(func.ToString());
            Console.WriteLine(func.Calculate());

            var op1 = new Plus();
            var op2 = new Plus();
            Console.WriteLine(op1 == op2);
            Console.WriteLine(op1 == "+");
        }
    }
}