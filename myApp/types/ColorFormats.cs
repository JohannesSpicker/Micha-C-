using System;
using System.Runtime.InteropServices;

namespace PR250.Types {

  //-------------------------------------------------------------------------
  // Bit Operations

  public class ColorFormats {

    public static class BitConversion {

      public static uint RGBA (byte r, byte g, byte b, byte a) {
        return 0; //TODO
      }
      public static void ExtractRGBA (uint rgba, out byte r, out byte g, out byte b, out byte a) {
        r = 0; //TODO
        g = 0; //TODO
        b = 0; //TODO
        a = 0; //TODO
      }

      public static uint ARGB (byte a, byte r, byte g, byte b) {
        return 0; //TODO
      }
      public static void ExtractARGB (uint argb, out byte a, out byte r, out byte g, out byte b) {
        a = 0; //TODO
        r = 0; //TODO
        g = 0; //TODO
        b = 0; //TODO
      }
    }

    //-------------------------------------------------------------------------
    // Struct based Conversion

    //TODO
    public struct RGBA {
      /*TODO*/ public uint Value;
      /*TODO*/ public byte R;
      /*TODO*/ public byte G;
      /*TODO*/ public byte B;
      /*TODO*/ public byte A;

      public RGBA (byte r, byte g, byte b, byte a) : this () {
        R = r;
        G = g;
        B = b;
        A = a;
      }
      public RGBA (uint value) : this () {
        Value = value;
      }

      override public string ToString () { return string.Format ("(R={0,3},G={1,3},B={2,3},A={3,3}) = {4:X}", R, G, B, A, Value); }
    }

    //TODO
    public struct ARGB {
      /*TODO*/ public uint Value;
      /*TODO*/ public byte A;
      /*TODO*/ public byte R;
      /*TODO*/ public byte G;
      /*TODO*/ public byte B;

      public ARGB (byte a, byte r, byte g, byte b) : this () {
        A = a;
        R = r;
        G = g;
        B = b;
      }
      public ARGB (uint value) : this () {
        Value = value;
      }

      override public string ToString () { return string.Format ("(A={0,3},R={1,3},G={2,3},B={3,3}) = {4:X}", A, R, G, B, Value); }
    }

    //-------------------------------------------------------------------------
    // Main

    public static void Test () {
      uint color = 0xFFC08040;
      TestBitConversion (color);
      TestStructConversion (color);
    }

    static void TestBitConversion (uint value) {
      Console.WriteLine (nameof (TestBitConversion));
      uint rgba, argb;
      byte r, g, b, a;

      rgba = value;
      BitConversion.ExtractRGBA (rgba, out r, out g, out b, out a);
      rgba = BitConversion.RGBA (r, g, b, a); // uncessary, just for testing test
      Console.WriteLine ("(R={0,3},G={1,3},B={2,3},A={3,3}) = {4:X}", r, g, b, a, rgba);
      argb = BitConversion.ARGB (a, r, g, b);
      BitConversion.ExtractARGB (argb, out a, out r, out g, out b); // uncessary, just for testing test
      Console.WriteLine ("(A={0,3},R={1,3},G={2,3},B={3,3}) = {4:X}", a, r, g, b, argb);

      Console.WriteLine ();
    }

    static void TestStructConversion (uint value) {
      Console.WriteLine (nameof (TestStructConversion));
      RGBA rgba;
      ARGB argb;

      rgba = new RGBA (value);
      Console.WriteLine (rgba);

      argb = new ARGB (rgba.A, rgba.R, rgba.G, rgba.B);
      Console.WriteLine (argb);

      Console.WriteLine ();
    }

    //-------------------------------------------------------------------------
  }
}