using System;
using System.Collections;
using System.Collections.Generic;

namespace PR250.Linear {

  public interface IArrayLike<T> : IEnumerable<T> {
    int Length { get; }
    T this [int index] { get; set; }
  }

  //---------------------------------------------------------------------

  public interface IArrayInsert<T> {
    void InsertAt (int index, T elem);
  }

  //---------------------------------------------------------------------

  public interface IArrayRemove<T> {
    T RemoveAt (int index);
  }

  //---------------------------------------------------------------------

  public interface IStack<T> {
    void Push (T elem);
    T Pop ();
    int Size { get; }
    T Last { get; }
  }

  //---------------------------------------------------------------------

  public interface IQueue<T> {
    void Enqueue (T elem);
    T Dequeue ();

    int Size { get; }
    T First { get; }
  }

  //---------------------------------------------------------------------

  public interface IDeque<T> {
    void Prepend (T elem);
    void Append (T elem);

    T RemoveFirst ();
    T RemoveLast ();

    int Size { get; }
    T First { get; }
    T Last { get; }
  }

}