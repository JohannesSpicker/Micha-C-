using System;
using System.Collections;
using System.Collections.Generic;

namespace PR250.Linear {
  public class DynamicCircularArray<T> : IArrayLike<T>, IArrayInsert<T>, IArrayRemove<T>, IStack<T>, IQueue<T>, IDeque<T> {
    private T[] elements;
    private int first;

    public DynamicCircularArray (int initialCapacity = 0) {
      elements = new T[initialCapacity];
    }

    public int Length { get; private set; }

    public int Capacity => elements.Length;

    public T this [int index] {
      get => elements[(index + first) % Capacity];
      set => elements[(index + first) % Capacity] = value;
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

    void IStack<T>.Push (T elem) {} //TODO

    T IStack<T>.Pop () => default; //TODO

    //---------------------------------------------------------------------
    // Queue

    int IQueue<T>.Size => default; //TODO

    void IQueue<T>.Enqueue (T elem) {} //TODO

    T IQueue<T>.Dequeue () => default; //TODO

    //---------------------------------------------------------------------
    // Deque

    int IDeque<T>.Size => default; //TODO

    public T First => default; //TODO

    public T Last => default; //TODO

    public void Prepend (T elem) {} //TODO

    public void Append (T elem) {} //TODO

    public T RemoveFirst () => default; //TODO

    public T RemoveLast () => default; //TODO

    //---------------------------------------------------------------------

    public IEnumerator<T> GetEnumerator () => Utils.GetEnumerator (this);

    IEnumerator IEnumerable.GetEnumerator () => GetEnumerator ();

    //---------------------------------------------------------------------
  }
}