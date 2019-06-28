using System;
using PR250.Types;

namespace PR250
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n================================================= \n");
            Console.WriteLine("=================== Bit Logic ==================== \n");
            BitLogicTest.Test();
            Console.WriteLine("=================== Bit Operations =============== \n");
            BitOperations.Test();
            Console.WriteLine("=================== Fixed Point ================== \n");
            FixPoint.Test();
            Console.WriteLine("=================== Color Formats ================ \n");            
            ColorFormats.Test();
            Console.WriteLine("=================== Linear ======================= \n");            
            Linear.Program.Test();
            Console.WriteLine("\n================================================= \n");
        } 
    }
}