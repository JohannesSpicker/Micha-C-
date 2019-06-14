using System;

namespace PR250.Types
{

    public static class BitOperations
    {

        //-------------------------------------------------------------------------
        // Bit access

        public static uint GetMask(int bit) => (uint) 1 << bit;

        public static bool GetBit(uint number, int bit) => 0 != (number & GetMask(bit));

        public static uint SetBit(uint number, int bit) => number | GetMask(bit);

        public static uint ClearBit(uint number, int bit) => number & ~GetMask(bit);
        
        public static uint ToggleBit(uint number, int bit) => number ^ GetMask(bit);

        //-------------------------------------------------------------------------
        // Bits - bool array conversion

        public static bool[] ToArray(uint number)
        {
            var bits = new bool[32];
            for (int i = 0; i < bits.Length; i++)
            {
                bits[i] = GetBit(number, i);
            }
            return bits;
        }
        public static uint FromArray(bool[] bits)
        {
            Array.Resize(ref bits, 32); // make sure there are exactly 32 elements
            uint number = 0; // initialise on false, so we'd actually only have to write the true bits in

            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i])
                    number = SetBit(number, i);
                else
                    ClearBit(number, i);
            }

            //TODO
            return number;
        }

        //-------------------------------------------------------------------------
        // Main

        public static void Test()
        {
            var r = new Random(987354);
            var bits = new bool[32];
            for (int i = 0; i < bits.Length; i++)
            {
                bits[i] = r.Next(2) > 0 ? true : false;
            }

            Console.WriteLine("Bits: {0}", BitString(bits));
            uint bitfield = FromArray(bits);
            Console.WriteLine("BitField: {0}", bitfield);

            var bits2 = ToArray(bitfield);

            bool eq = true;
            for (int i = 0; i < bits.Length; i++)
            {
                eq &= bits[i] == bits2[i];
            }
            Console.WriteLine("Conversions are {0}!", eq ? "valid" : "invalid");
        }

        static string BitString(bool[] bits)
        {
            var s = string.Empty;
            for (int i = 0; i < bits.Length; i++)
            {
                s += bits[i] ? '1' : '0';
            }
            return s;
        }

        //-------------------------------------------------------------------------
    }

}