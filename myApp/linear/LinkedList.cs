using System;
using System.Collections;
using System.Collections.Generic;

namespace PR250.Linear {
  public class LinkedList<T> : IEnumerable<T>, IStack<T>, IQueue<T>, IDeque<T> {

    //-----------------------------------------------------------------------

    public sealed class Node {

      private readonly LinkedList<T> list;
      public T Item;

      //---------------------------------------------------------------------

      internal Node (LinkedList<T> l, T elem) {
        list = l;
        Item = elem;
      }

      //---------------------------------------------------------------------

      public Node Previous { get; internal set; }
      public Node Next { get; internal set; }

      //---------------------------------------------------------------------
      public T Delete () {
        if (Previous != null) {
          Previous.Next = Next;
        } else {
          list.FirstNode = Next;
        }
        if (Next != null) {
          Next.Previous = Previous;
        } else {
          list.LastNode = Previous;
        }
        list.Length--;

        Previous = Next = null;
        return Item;
      }
      public Node InsertBefore (T elem) {
        if (Previous == null && Next == null) {
          return null; // already deleted
        }
        return list.InsertBefore (this, elem);
      }
      public Node InsertAfter (T elem) {
        if (Previous == null && Next == null) {
          return null; // already deleted
        }
        return list.InsertAfter (this, elem);
      }

    }

    //-----------------------------------------------------------------------

    public int Length { get; private set; }

    public Node FirstNode { get; private set; }
    public Node LastNode { get; private set; }

    public Node GetNodeAt (int index) {
      if (index * 2 < Length) {
        var node = FirstNode;
        for (int i = 0; i < index; i++) {
          node = node.Next;
        }
        return node;
      } else {
        var node = LastNode;
        for (int i = Length - 1; i > index; i--) {
          node = node.Previous;
        }
        return node;
      }
    }

    private Node InsertBefore (Node node, T elem) {
      var before = new Node (this, elem);
      if (node != null) {
        if (node.Previous != null) {
          node.Previous.Next = before;
        } else {
          FirstNode = before;
        }
        before.Previous = node.Previous;
        before.Next = node;
        node.Previous = before;
      } else {
        FirstNode = LastNode = before;
      }
      Length++;
      return before;
    }
    private Node InsertAfter (Node node, T elem) {
      var after = new Node (this, elem);
      if (node != null) {
        if (node.Next != null) {
          node.Next.Previous = after;
        } else {
          LastNode = after;
        }
        after.Next = node.Next;
        after.Previous = node;
        node.Next = after;
      } else {
        FirstNode = LastNode = after;
      }
      Length++;
      return after;
    }

    //-----------------------------------------------------------------------    

    int IStack<T>.Size => default; //TODO

    void IStack<T>.Push (T elem) {} //TODO

    T IStack<T>.Pop () => default; //TODO

    //-----------------------------------------------------------------------+

    int IQueue<T>.Size => default; //TODO

    void IQueue<T>.Enqueue (T elem) {} //TODO

    T IQueue<T>.Dequeue () => default; //TODO

    //-----------------------------------------------------------------------

    int IDeque<T>.Size => default; //TODO

    public T First => default; //TODO
    public T Last => default; //TODO

    public void Prepend (T elem) {} //TODO

    public void Append (T elem) {} //TODO

    public T RemoveFirst () => default; //TODO

    public T RemoveLast () => default; //TODO

    //-----------------------------------------------------------------------

    public IEnumerator<T> GetEnumerator () {
      var node = FirstNode;
      while (node != null) {
        yield return node.Item;
        node = node.Next;
      }
    }

    IEnumerator IEnumerable.GetEnumerator () => GetEnumerator ();

    //-----------------------------------------------------------------------
  }
}