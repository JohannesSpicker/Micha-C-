using System;

namespace PR250.Types
{


    //-------------------------------------------------------------------------
    // Logical operators
    //-------------------------------------------------------------------------

    public static class BitLogic
    {

        //public static uint NOT (uint a) => 0; // TODO
        public static uint NOT(uint a) => ~a;

        public static uint OR(uint a, uint b) => a | b;

        public static uint AND(uint a, uint b) => a & b;
        public static uint XOR(uint a, uint b) => a ^ b;

        public static uint NAND(uint a, uint b) => ~(a & b);

        public static uint NOR(uint a, uint b) => ~(a | b);
    }

    //-------------------------------------------------------------------------
    // Logical operators based on NOR
    //-------------------------------------------------------------------------

    public static class BitLogicNOR
    {
        public static uint NOR(uint a, uint b) => BitLogic.NOR(a, b);

        public static uint NOT(uint a) => NOR(a, a); // 1

        public static uint OR(uint a, uint b) => NOT(NOR(a, b)); // 2

        public static uint AND(uint a, uint b) => NOR(NOT(a), NOT(b)); // 3

        public static uint NAND(uint a, uint b) => OR(NOT(a), NOT(b)); // 4

        public static uint XOR(uint a, uint b) => NOR(NOR(a,b), AND(a,b)); // 5
    }

    //-------------------------------------------------------------------------
    // Logical operators based on NAND
    //-------------------------------------------------------------------------

    public static class BitLogicNAND
    {
        public static uint NAND(uint a, uint b) => BitLogic.NAND(a, b);

        public static uint NOT(uint a) => NAND(a, a); // 1

        public static uint AND(uint a, uint b) => NOT(NAND(a, b)); // 2

        public static uint OR(uint a, uint b) => NAND(NOT(a), NOT(b)); // 3

        public static uint NOR(uint a, uint b) => NOT(OR(a, b)); // 4

        public static uint XOR(uint a, uint b) => AND(NAND(a, b), OR(a, b)); // 6
    }

    public static class BitLogicTest
    {
        public static void Test()
        {
            uint a = 0xC0FFEE;
            // uint b = 0x123ABC;
            uint b = a;
            Console.WriteLine("Test-NOR: NOT  = " + (BitLogic.NOT(a) == BitLogicNOR.NOT(a)));
            Console.WriteLine("Test-NOR: OR   = " + (BitLogic.OR(a, b) == BitLogicNOR.OR(a, b)));
            Console.WriteLine("Test-NOR: AND  = " + (BitLogic.AND(a, b) == BitLogicNOR.AND(a, b)));
            Console.WriteLine("Test-NOR: XOR  = " + (BitLogic.XOR(a, b) == BitLogicNOR.XOR(a, b)));
            Console.WriteLine("Test-NOR: NAND = " + (BitLogic.NAND(a, b) == BitLogicNOR.NAND(a, b)));
            Console.WriteLine();
            Console.WriteLine("Test-NAND: NOT  = " + (BitLogic.NOT(a) == BitLogicNAND.NOT(a)));
            Console.WriteLine("Test-NAND: OR   = " + (BitLogic.OR(a, b) == BitLogicNAND.OR(a, b)));
            Console.WriteLine("Test-NAND: AND  = " + (BitLogic.AND(a, b) == BitLogicNAND.AND(a, b)));
            Console.WriteLine("Test-NAND: XOR  = " + (BitLogic.XOR(a, b) == BitLogicNAND.XOR(a, b)));
            Console.WriteLine("Test-NAND: NOR  = " + (BitLogic.NOR(a, b) == BitLogicNAND.NOR(a, b)));
        }

        //-------------------------------------------------------------------------
    }

}