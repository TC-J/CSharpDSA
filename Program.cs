namespace csdsa;

class Program
{
    static int Main(string[] argv)
    {
        RunBinaryTree();
        return 0;
    }

    static void RunBinaryTree()
    {
        var bt = new BinaryTree<int, int>();
        bt.Insert(10, 1);
        bt.Insert(-20, 2);
        bt.Insert(20, 3);
        bt.Insert(25, 4);
        bt.Insert(15, 5);
        bt.Insert(-15, 6);
        bt.Insert(-25, 7);

        var v0 = bt.Root!.Value;
        var v1 = bt.Root!.Left!.Value;
        var v2 = bt.Root!.Right!.Value;
        var v3 = bt.Root!.Right!.Right!.Value;
        var v4 = bt.Root!.Right!.Left!.Value;
        var v5 = bt.Root!.Left!.Right!.Value;
        var v6 = bt.Root!.Left!.Left!.Value;
        Console.WriteLine("Root => {0}", v0);
        Console.WriteLine("Root.Left => {0}", v1);
        Console.WriteLine("Root.Right => {0}", v2);
        Console.WriteLine("Root.Right.Right => {0}", v3);
        Console.WriteLine("Root.Right.Left => {0}", v4);
        Console.WriteLine("Root.Left.Right => {0}", v5);
        Console.WriteLine("Root.Left.Left => {0}", v6);

        var v7 = bt.Root!.Search(20)!.Value;
        Console.WriteLine("Search Key {0} => {1}", 20, v7);

        var d0 = bt.Root!.Depth(-25);
        Console.WriteLine("Depth of Key {0} => {1}", -25, d0);

        var d1 = bt.Root!.Depth(-20);
        Console.WriteLine("Depth of Key {0} => {1}", -20, d1);

        var d2 = bt.Root!.Depth(10);
        Console.WriteLine("Depth of Key {0} => {1}", 10, d2);

        var d3 = bt.Root!.Depth(20);
        Console.WriteLine("Depth of Key {0} => {1}", 20, d3);

        var d4 = bt.Root!.Depth(25);
        Console.WriteLine("Depth of Key {0} => {1}", 25, d4);

        bt.Root!.Left!.Inorder((k, v) =>
        {
            Console.WriteLine("Key {0} => {1}", k, v);
        });

        Console.WriteLine();

        bt.Inorder((k, v) =>
        {
            Console.WriteLine("Key {0} => {1}", k, v);
        });

        Console.WriteLine();

        bt.Inorder((k, v) =>
        {
            Console.WriteLine("Key {0} => {1}", k, v);
        });

    }
    static void RunQueue()
    {
        Queue<int> q = new Queue<int>();
        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(3);
        Console.WriteLine("size => {0}", q.Size());
        Console.WriteLine("dequeue => {0}", q.Dequeue());
        Console.WriteLine("dequeue => {0}", q.Dequeue());
        Console.WriteLine("dequeue => {0}", q.Dequeue());
        Console.WriteLine("size => {0}", q.Size());

    }

    static void RunStack()
    {
        var stack = new Stack<int>();

        stack.Push(9);
        Console.WriteLine("Push => {0}, size {1}", 9, stack.Size());
        stack.Push(10);
        Console.WriteLine("Push => {0}, size {1}", 10, stack.Size());

        Console.WriteLine("Pop => {0}, new size {1}", stack.Pop(), stack.Size());
        Console.WriteLine("Pop => {0}, new size {1}", stack.Pop(), stack.Size());
    }

    static void RunLinkedList()
    {
        LinkedList<int> ll = new LinkedList<int>(1);
        ll.Prepend(0);
        ll.Append(2);
        ll.Prepend(-1);
        ll.Append(3);
        ll.Prepend(-2);
        ll.Prepend(-3);
        Console.WriteLine(ll);

        Console.WriteLine();

        ll.Delete(0);
        ll.Delete(1);
        ll.Delete(4);
        Console.WriteLine(ll);

        ll.Insert(1, -1);
        ll.Insert(5, 3);
        ll.Insert(0, -3);
        Console.WriteLine(ll);

        Console.WriteLine("First Item => {0}", ll.Get(0)!);
        Console.WriteLine("Last Item => {0}", ll.Get((uint)(ll.Size() - 1))!);

        int v = 2;
        int s0 = ll.Search(v);
        Console.WriteLine("search for value {0} => found at index {1}, confirm ll.Get({1}) => {2}", v, s0, ll.Get((uint)s0)!);

        v = -3;
        s0 = ll.Search(v);
        Console.WriteLine("search for value {0} => found at index {1}, confirm ll.Get({1}) => {2}", v, s0, ll.Get((uint)s0)!);

        v = 3;
        s0 = ll.Search(v);
        Console.WriteLine("search for value {0} => found at index {1}, confirm ll.Get({1}) => {2}", v, s0, ll.Get((uint)s0)!);

    }
}