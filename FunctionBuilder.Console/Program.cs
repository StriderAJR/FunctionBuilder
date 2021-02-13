namespace FunctionBuilder.Console
{
    using FunctionBuilder.Logic;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(new Function("(1/3+0.5)+2*(4-1/2)").ToString());
        }
    }
}