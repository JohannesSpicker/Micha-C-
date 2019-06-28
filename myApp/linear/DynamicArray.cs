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
      elements[index] = elem;

      for (int i = Length; index < i; i--)
      {
          this[i] = this[i-1];
      }

      this[index] = elem;
      Length++;
    }

    public T RemoveAt (int index) {
      var output = this[index];

      Length--;
      for (int i = index; i < Length; i++)
      {
          this[i] = this[i+1];
      }

      return output;
    }

    private void EnsureCapacity () {
      if(Length < Capacity)
      {
        return;
      } 
      
      var temp = new T[1 << Length];

      for (int i = 0; i < Length; i++)
      {
          temp[i] = this[i];
      }

      elements = temp;
    }

    //---------------------------------------------------------------------
    // Stack

    int IStack<T>.Size => Length;

    public T Last => this[Length - 1];

    void IStack<T>.Push (T elem) => InsertAt(Length, elem);

    T IStack<T>.Pop () => RemoveAt(Length - 1);

    //---------------------------------------------------------------------
    // Deque - partial

    public T First => this[0];

    public void Append (T elem) => InsertAt(Length, elem);

    public T RemoveLast () => RemoveAt(Length - 1);

    //---------------------------------------------------------------------

    public IEnumerator<T> GetEnumerator () => Utils.GetEnumerator (this);

    IEnumerator IEnumerable.GetEnumerator () => GetEnumerator ();

    //---------------------------------------------------------------------
  }
}