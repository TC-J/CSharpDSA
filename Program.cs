namespace csdsa;

class Program
{
    static int Main(string[] argv)
    {
        RunStack();
        return 0;
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