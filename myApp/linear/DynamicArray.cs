using System;
using System.Collections;
using System.Collections.Generic;

namespace PR250.Linear {
  public class DynamicArray<T> : IArrayLike<T>, IArrayInsert<T>, IArrayRemove<T>, IStack<T> {
    private T[] elements;

    public DynamicArray (int initialCapacity = 0) {
      elements = new T[initialCapacity];
    }

    public int Length { get; private set; }

    public int Capacity => elements.Length;

    public T this [int index] {
      get => elements[index];
      set => elements[index] = value;
    }

    //---------------------------------------------------------------------

    public void InsertAt (int index, T elem) {
      EnsureCapacity ();
      //TODO
    }

    public T RemoveAt (int index) {
      //TODO
      return default;
    }

    private void EnsureCapacity () {
      //TODO
    }

    //---------------------------------------------------------------------
    // Stack

    int IStack<T>.Size => default; //TODO

    public T Last => default; //TODO

    void IStack<T>.Push (T elem) {} //TODO

    T IStack<T>.Pop () => default; //TODO

    //---------------------------------------------------------------------
    // Deque - partial

    public T First => default; //TODO

    public void Append (T elem) {} //TODO

    public T RemoveLast () => default; //TODO

    //---------------------------------------------------------------------

    public IEnumerator<T> GetEnumerator () => Utils.GetEnumerator (this);

    IEnumerator IEnumerable.GetEnumerator () => GetEnumerator ();

    //---------------------------------------------------------------------
  }
}