namespace csdsa;

class LinkedList<T> : ILinkedList<T>
where T : IComparable, IEquatable<T>
{
    class Node<V> : IComparable<V>, IEquatable<Node<V>>
    where V : IComparable, IEquatable<V>
    {

        public Node<V>? Next { get; set; }

        public V Data { get; set; }

        public Node(V data)
        {
            this.Data = data;
        }


        public override string ToString()
        {
            return "" + this.Data;
        }

        int IComparable<V>.CompareTo(V? other)
        {
            return this.Data.CompareTo(other);
        }

        bool IEquatable<LinkedList<T>.Node<V>>.Equals(LinkedList<T>.Node<V>? other)
        {
            if (other == null) { return false; }
            else
            {
                return other.Data.Equals(this.Data);
            }
        }
    }

    private Node<T>? Head { get; set; }

    public LinkedList() { }

    public LinkedList(T value)
    {
        this.Head = new Node<T>(value);
    }

    public void Prepend(T value)
    {
        var node = new Node<T>(value);

        if (this.Head == null)
        {
            this.Head = node;
            return;
        }

        node.Next = this.Head;

        this.Head = node;
    }

    public void Append(T value)
    {
        if (this.Head == null)
        {
            this.Head = new Node<T>(value);
            return;
        }

        Node<T> node = this.Head;

        while (node.Next != null) { node = node.Next; }

        node.Next = new Node<T>(value);
    }

    public bool Insert(uint index, T value)
    {
        if (this.Head == null && index != 0) { return false; }
        else if (this.Head == null)
        {
            this.Head = new Node<T>(value);
            return true;
        }
        else if (index == 0)
        {
            var tmp = this.Head;
            this.Head = new Node<T>(value);
            this.Head.Next = tmp;
            return true;
        }
        else
        {
            var node = this.Head!;
            while (index != 1)
            {

                if (node.Next == null) { return false; }

                node = node.Next;

                index--;
            }

            if (node.Next == null)
            {
                node.Next = new Node<T>(value);
            }
            else
            {
                var next = node.Next;
                node.Next = new Node<T>(value);
                node.Next.Next = next;
            }

            return true;
        }
    }

    public int Size()
    {
        int rv = 1;

        var node = this.Head;

        if (this.IsEmpty()) { return 0; }
        else
        {
            while (node!.Next != null) { node = node.Next; rv++; }

            return rv;
        }
    }

    public bool IsEmpty() { return this.Head == null; }

    public T? Get(uint index)
    {
        if (this.Head == null) { return default(T); }
        else
        {
            var node = this.Head;
            while (index != 0)
            {
                if (node.Next == null)
                {
                    return default(T);
                }
                else
                {
                    node = node.Next;
                }
                index--;
            }

            return node.Data;
        }
    }

    public void Delete(uint index)
    {
        Node<T>? node = this.Head;
        Node<T>? prev = node;

        if (node != null && index == 0)
        {
            this.Head = node.Next;
            return;
        }

        while (node != null && index > 0)
        {
            prev = node;
            node = node.Next;
            index--;
        }
        if (node == null) { return; }
        else
        {
            prev!.Next = node.Next;
        }
    }

    public int Search(T value)
    {
        int index = 0;
        var node = this.Head;

        if (node == null) { return -1; }
        else
        {
            while (!node!.Data.Equals(value))
            {
                node = node.Next;
                if (node == null) { return -1; }
                index++;
            }

            return index;
        }
    }

    public override string ToString()
    {
        Node<T> node = this.Head!;

        string rv = "< llist[" + this.Size() + "]\n\t{ " + this.Head + " }";

        while (node.Next != null)
        {
            node = node.Next;
            rv += "\n\t{ " + node + " }";
        }

        return rv + "\n>";
    }
}