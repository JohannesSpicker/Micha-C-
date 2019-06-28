using System;
using System.Collections;
using System.Collections.Generic;

namespace PR250.Linear {

  public static class Utils {

    public static T[] ToArray<T> (this IArrayLike<T> elements) {
      var array = new T[elements.Length];
      for (int i = 0; i < array.Length; i++) {
        array[i] = elements[i];
      }
      return array;
    }

    public static IEnumerator<T> GetEnumerator<T> (this IArrayLike<T> elements) {
      for (int i = 0, n = elements.Length; i < n; i++) {
        yield return elements[i];
      }
    }

    public static int Find<T> (this IArrayLike<T> elements, T elem, int start = 0) {
      for (int i = start, n = elements.Length; i < n; i++) {
        if (elements[i].Equals (elem)) {
          return i;
        }
      }
      return -1;
    }

    public static IArrayLike<T> Slice<T> (this IArrayLike<T> elements, int start, int length) {
      return new Slice<T> (elements, start, length);
    }

  }

  //---------------------------------------------------------------------

  sealed class Slice<T> : IArrayLike<T> {
    private readonly IArrayLike<T> elems;
    private readonly int k, n;

    public Slice (IArrayLike<T> elements, int start, int length) {
      elems = elements;
      k = start;
      n = length;
    }

    public int Length => n;

    public T this [int index] {
      get => elems[k + index];
      set => elems[k + index] = value;
    }

    public IEnumerator<T> GetEnumerator () => Utils.GetEnumerator (this);

    IEnumerator IEnumerable.GetEnumerator () => GetEnumerator ();
  }

}