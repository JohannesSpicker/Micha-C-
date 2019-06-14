using System;

namespace PR250.Types {
  public class FixPoint {

    //-------------------------------------------------------------------------

    public static FixPoint Binary(byte radix) => new FixPoint(Math.Pow(2, radix)); //TODO return a FixPoint with the specified binary radix

    public static FixPoint Decimal(byte radix) => new FixPoint(Math.Pow(10, radix)); //TODO return a FixPoint with the specified decimal radix

    private readonly double scale;

    private FixPoint(double s) {//constructor
      scale = s;
    }

    public long FromFloat(double number) => (long) Math.Round(number * scale);// convert the floating point number to a fix point number with converter instance scale

    public double ToFloat(long number) => number / scale; // convert the fix point number to a floating point number with converter instance scale //implicit casting from long to double

    public long Add(long a, long b) => a+b;
    
    public long Mul(long a, long b) => (long) Math.Round((a*b) / scale);

    public long Div(long a, long b) => (a*(long)scale/b);

    //-------------------------------------------------------------------------
    // Main

    public static void Test () {
      TestDecBin(1.234, 2, 7);   // dec: 10^2 = 100, bin: 2^7 = 128
      TestDecBin(1.024, 2, 7);   // dec: 10^2 = 100, bin: 2^7 = 128
    }

    private static void TestDecBin (double f, byte d, byte b) {
      FixPoint dec = FixPoint.Decimal(d); // 10^2 = 100
      FixPoint bin = FixPoint.Binary(b);  //  2^7 = 128

      Console.WriteLine("Float: {0}", f);

      long fixDec = dec.FromFloat(f);
      long fixBin = bin.FromFloat(f);
      Console.WriteLine("Fix-Dec: {0}, Fix-Bin: {1}", fixDec, fixBin);

      double floatDec = dec.ToFloat(fixDec);
      double floatBin = bin.ToFloat(fixBin);
      Console.WriteLine("Float-Dec: {0}, Float-Bin: {1}", floatDec, floatBin);
      Console.WriteLine();
    }

    //-------------------------------------------------------------------------
  }
}