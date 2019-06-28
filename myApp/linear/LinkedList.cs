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

      public Node Previous { get; internal set; }
      public Node Next { get; internal set; }

      //---------------------------------------------------------------------

      internal Node (LinkedList<T> l, T elem) {
        list = l;
        Item = elem;
      }

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

    public T this[int index] => GetNodeAt(index).Item;

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

    int IStack<T>.Size => Length; 

    void IStack<T>.Push (T elem) => InsertAfter(LastNode, elem);

    T IStack<T>.Pop () => LastNode.Delete();

    //-----------------------------------------------------------------------+

    int IQueue<T>.Size => Length;

    void IQueue<T>.Enqueue (T elem) => InsertAfter(LastNode, elem);

    T IQueue<T>.Dequeue () => FirstNode.Delete();

    //-----------------------------------------------------------------------

    int IDeque<T>.Size => Length; //TODO

    public T First => FirstNode.Item;
    public T Last => LastNode.Item;

    public void Prepend (T elem) => InsertBefore(FirstNode, elem);

    public void Append (T elem) => InsertAfter(LastNode, elem);

    public T RemoveFirst () => FirstNode.Delete();

    public T RemoveLast () => LastNode.Delete();

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