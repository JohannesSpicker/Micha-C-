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
      EnsureCapacity();
      this[index] = elem;

      if(index < Length / 2)
      {
        first = (first - 1 + Capacity) % Capacity;

        for (int i = 0; i < index; i++)
        {
            this[i] = this[i+1];
        }
      } else
      {         
        for (int i = Length; index < i; i--)
        {
            this[i] = this[i-1];
        }
      }

      this[index] = elem;
      Length++;
    }

    public T RemoveAt (int index) {
      var output = this[index];

      Length--;

      if(index < Length / 2)
      {
        for (int i = index; 0 < i; i--)
        {
            this[i] = this[i-1];
        }
        first = (first+1) % Capacity;
      } else
      {
        for (int i = index; i < Length; i++)
        {
            this[i] = this[i+1];
        }
      }
      
      Length--;

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

    void IStack<T>.Push (T elem) => InsertAt(Length, elem);

    T IStack<T>.Pop () => RemoveAt(Length - 1);

    //---------------------------------------------------------------------
    // Queue

    int IQueue<T>.Size => Length;

    void IQueue<T>.Enqueue (T elem) => InsertAt(Length, elem);

    T IQueue<T>.Dequeue () => RemoveAt(0);

    //---------------------------------------------------------------------
    // Deque

    int IDeque<T>.Size => Length;

    public T First => this[0];

    public T Last => this[Length - 1];

    public void Prepend (T elem) => InsertAt(0, elem);

    public void Append (T elem) => InsertAt(Length, elem);

    public T RemoveFirst () => RemoveAt(0);

    public T RemoveLast () => RemoveAt(Length - 1);

    //---------------------------------------------------------------------

    public IEnumerator<T> GetEnumerator () => Utils.GetEnumerator (this);

    IEnumerator IEnumerable.GetEnumerator () => GetEnumerator ();

    //---------------------------------------------------------------------
  }
}