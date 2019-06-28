namespace PR250.Linear {

  using System;

  public static class Program {

    static bool TestStack(IStack<int> stack, int n) {
      if (stack.Size != 0) {
        return false;
      }
      for(int i=0; i<n; i++) {
        stack.Push(i);
        stack.Pop();
        stack.Push(i);
      }
      if (stack.Size != n) {
        return false;
      }
      if (n > 0 && stack.Last != n-1) {
        return false;
      }
      int elem = -1;
      for(int i=0; i<n; i++) {
        elem = stack.Pop();
      }
      if (stack.Size != 0 || elem != 0) {
        return false;
      }
      return true;
    }

    static bool TestQueue(IQueue<int> queue, int n) {
      if (queue.Size != 0) {
        return false;
      }
      queue.Enqueue(-1);
      for(int i=0; i<n; i++) {
        queue.Enqueue(i);
        queue.Dequeue();
        queue.Enqueue(i);
      }
      if (queue.Size != n+1) {
        return false;
      }
      if (n > 0 && queue.First != (n+1) / 2 - 1) {
        return false;
      }
      int elem = -1;
      for(int i=0; i<=n; i++) {
        elem = queue.Dequeue();
      }
      if (queue.Size != 0 || elem != n-1) {
        return false;
      }
      return true;
    }

    static bool TestDeque(IDeque<int> deque, int n) {
      if (deque.Size != 0) {
        return false;
      }
      for(int i=0; i<n; i++) {
        deque.Prepend(i);
        deque.Append(i);
        deque.RemoveFirst();
      }

      if (deque.Size != n) {
        return false;
      }
      if (n > 0 && (deque.First != 0 || deque.Last != n - 1)) {
        return false;
      }
      int elem = -1;
      for(int i=0; i<n; i++) {
        elem = deque.RemoveLast();
      }
      if (deque.Size != 0 || elem != 0) {
        return false;
      }
      return true;
    }

    static bool TestDCA(DynamicCircularArray<int> dca, int n) {
      if (dca.Length != 0) {
        return false;
      }
      for(int i=0; i<n; i++) {
        dca.InsertAt(i/2, i);
        dca.Append(i);
        dca.RemoveFirst();
      }

      if (dca.Length != n) {
        return false;
      }
      if (n > 0 && dca.Last != n - 1) {
        return false;
      }
      int elem = -1;
      for(int i=0; i<n; i++) {
        elem = dca.RemoveAt((dca.Length-1)/2);
      }
      if (dca.Length != 0 || elem != n-1) {
        return false;
      }
      return true;
    }

    public static void Test () {
      int n = 100;

      Console.WriteLine($"Stack|DynamicArray|{n}: {TestStack(new DynamicArray<int>(), n)}");
      Console.WriteLine($"Stack|DynamicCircularArray|{n}: {TestStack(new DynamicCircularArray<int>(), n)}");
      Console.WriteLine($"Stack|LinkedList|{n}: {TestStack(new LinkedList<int>(), n)}");

      Console.WriteLine($"Queue|DynamicCircularArray|{n}: {TestQueue(new DynamicCircularArray<int>(), n)}");
      Console.WriteLine($"Queue|LinkedList|{n}: {TestQueue(new LinkedList<int>(), n)}");

      Console.WriteLine($"Deque|DynamicCircularArray|{n}: {TestDeque(new DynamicCircularArray<int>(), n)}");
      Console.WriteLine($"Deque|LinkedList|100: {n}: {TestDeque(new LinkedList<int>(), n)}");

      Console.WriteLine($"TestMiddle|DynamicCircularArray|{n}: {TestDCA(new DynamicCircularArray<int>(), n)}");
    }
  }
}