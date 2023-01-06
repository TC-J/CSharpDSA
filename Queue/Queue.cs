namespace csdsa;

class Queue<T> : IQueue<T>
{
    class Node<V>
    {
        public Node<V>? Next { get; set; }

        public V Data { get; set; }

        public Node(V data)
        {
            this.Data = data;
        }
    }

    Node<T>? Head;

    public T? Dequeue()
    {
        if (this.Head == null)
        {
            return default(T);
        }
        else
        {
            var head = this.Head;

            this.Head = this.Head.Next;

            return head.Data;
        }
    }

    public void Enqueue(T value)
    {
        if (this.Head == null)
        {
            this.Head = new Node<T>(value);
            return;
        }
        else
        {
            var node = this.Head;
            while (node.Next != null) { node = node.Next; }
            node.Next = new Node<T>(value);
        }
    }

    public bool IsEmpty()
    {
        return this.Size() == 0;
    }

    public int Size()
    {
        int count = 0;
        if (this.Head != null)
        {
            var node = this.Head;
            count++;
            while (node.Next != null) { count++; node = node.Next; }
        }

        return count;
    }
}