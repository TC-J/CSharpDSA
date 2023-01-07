namespace csdsa;

class BinaryTree<K, V> : IBinaryTree<K, V>
    where K : IComparable<K>, IEquatable<K>
{
    public class Node<KT, VT>
        where KT : IComparable<KT>, IEquatable<KT>
    {
        public Node<KT, VT>? Left { get; set; }

        public Node<KT, VT>? Right { get; set; }

        public KT Key { get; set; }

        public VT Value { get; set; }

        public Node(KT k, VT v)
        {
            this.Key = k;
            this.Value = v;
        }

        public void Insert(KT k, VT v)
        {
            if (this.Key.CompareTo(k) > 0)
            {
                if (this.Left == null)
                {
                    this.Left = new Node<KT, VT>(k, v);
                    return;
                }
                else
                {
                    this.Left.Insert(k, v);
                }
            }
            else if (this.Key.CompareTo(k) < 0)
            {
                if (this.Right == null)
                {
                    this.Right = new Node<KT, VT>(k, v);
                }
                else
                {
                    this.Right.Insert(k, v);
                }
            }
            else
            {
                throw new ArgumentException("Key Exists");
            }
        }

        public Node<KT, VT>? Search(KT k)
        {
            if (this.Key.CompareTo(k) > 0)
            {
                if (this.Left == null) { return default; }
                else
                {
                    return this.Left.Search(k);
                }
            }
            else if (this.Key.CompareTo(k) < 0)
            {
                if (this.Right == null) { return default; }
                else
                {
                    return this.Right.Search(k);
                }
            }
            else
            {
                return this;
            }
        }

        int depth(KT k, int depth)
        {
            var comp = this.Key!.CompareTo(k);
            if (comp > 0)
            {
                return this.Left!.depth(k, ++depth);
            }
            else if (comp < 0)
            {
                return this.Right!.depth(k, ++depth);
            }
            else
            {
                return depth;
            }
        }

        public int Depth(KT k)
        {
            return this.depth(k, 0);
        }

        private static Node<KT, VT>? saveroot;

        public void Inorder(Action<KT, VT> lambda)
        {
            if (saveroot == null) { saveroot = this; }

            if (this.Left != null)
            {
                this.Left.Inorder(lambda);
                lambda(this.Left.Key, this.Left.Value);
            }

            if (this == saveroot)
            {
                lambda(this.Key, this.Value);
                if (this.Right != null)
                {
                    this.Right.Inorder(lambda);
                    lambda(this.Right.Key, this.Right.Value);
                }
                saveroot = default;
            }
            else if (this.Right != null)
            {
                this.Right.Inorder(lambda);
                lambda(this.Right.Key, this.Right.Value);
            }
        }

        public void Preorder(Action<KT, VT> lambda)
        { }
    }



    public Node<K, V>? Root { get; set; }


    public int Height()
    {
        throw new NotImplementedException();
    }

    public void Insert(K key, V value)
    {
        if (this.Root == null)
        {
            this.Root = new Node<K, V>(key, value);
            return;
        }
        else
        {
            this.Root.Insert(key, value);
        }
    }

    public int Level(K key)
    {
        if (this.Root == null)
        {
            return -1;
        }
        else
        {
            return this.Root!.Depth(key);
        }
    }

    public void Remove(K key)
    {
    }

    public V? Search(K key)
    {
        if (this.Root == null) { return default(V); }
        else
        {
            var node = this.Root.Search(key);
            if (node == null) { return default(V); }
            else
            {
                return node.Value;
            }
        }
    }

    public void Inorder(Action<K, V> lambda)
    {
        this.Root!.Inorder(lambda);
    }

    public int Size()
    {
        throw new NotImplementedException();
    }
}