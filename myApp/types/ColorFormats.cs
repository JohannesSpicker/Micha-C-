using System;
using System.Runtime.InteropServices;

namespace PR250.Types {

  //-------------------------------------------------------------------------
  // Bit Operations

  public class ColorFormats {

    public static class BitConversion {

      public static uint RGBA (byte r, byte g, byte b, byte a) => ((uint)r << 0) | ((uint)g << 8) | ((uint)b << 16) | ((uint)a << 24);
      public static void ExtractRGBA (uint rgba, out byte r, out byte g, out byte b, out byte a) {
        // 0b11111111 == 0xFF == 255
        // 0xFF == 0x000000FF
        // 0xFF00 == 0x0000FF00
        r = (byte) ((rgba >> 0) & 0xFF);
        g = (byte) ((rgba >> 8) & 0xFF);  // g = (byte) ((rgba & 0xFF00) >> 8);
        b = (byte) ((rgba >> 16) & 0xFF);
        a = (byte) ((rgba >> 24) & 0xFF); // a = (byte) ((rgba & 0xFF000000) >> 24);
      }

      public static uint ARGB (byte a, byte r, byte g, byte b) {
        return ((uint)r << 8) | ((uint)g << 16) | ((uint)b << 24) | ((uint)a << 0);
      }
      public static void ExtractARGB (uint argb, out byte a, out byte r, out byte g, out byte b) {
        a = (byte) ((argb >> 0) & 0xFF); // a = (byte) ((argb >> 0) & 0x00_00_00_0FF);
        r = (byte) ((argb >> 8) & 0xFF);
        g = (byte) ((argb >> 16) & 0xFF);
        b = (byte) ((argb >> 24) & 0xFF);
      }
    }

    //-------------------------------------------------------------------------
    // Struct based Conversion


    [StructLayout(LayoutKind.Explicit)]
    public struct RGBA {
      [FieldOffset(0)] public uint Value;
      [FieldOffset(0)] public byte R;
      [FieldOffset(1)] public byte G;
      [FieldOffset(2)] public byte B;
      [FieldOffset(3)] public byte A;

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

    [StructLayout(LayoutKind.Explicit)]
    public struct ARGB {
      [FieldOffset(0)] public uint Value;
      [FieldOffset(0)] public byte A;
      [FieldOffset(1)] public byte R;
      [FieldOffset(2)] public byte G;
      [FieldOffset(3)] public byte B;

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