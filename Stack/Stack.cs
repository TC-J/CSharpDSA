namespace csdsa;

class Stack<T> : IStack<T>
{
    class Node<V>
    {
        public Node<V>? Next { get; set; }
        public V Data { get; set; }

        public Node(V data)
        {
            Data = data;
        }
    }

    Node<T>? Top { get; set; }

    public bool Empty()
    {
        return this.Size() == 0;
    }

    public T? Pop()
    {
        var node = this.Top;
        if (node == null)
        {
            return default(T);
        }
        else
        {
            this.Top = this.Top!.Next;
            return node.Data;
        }
    }

    public void Push(T value)
    {
        var node = this.Top;

        if (node == null)
        {
            this.Top = new Node<T>(value);
        }
        else
        {
            this.Top = new Node<T>(value);
            this.Top.Next = node;
        }
    }

    public int Size()
    {
        int index = 0;
        var node = this.Top;
        if (node == null) { return index; }
        else
        {
            index++;
            while (node.Next != null) { index++; node = node.Next; }
        }

        return index;
    }
}