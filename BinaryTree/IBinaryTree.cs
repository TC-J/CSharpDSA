namespace csdsa;

interface IBinaryTree<K, T>
    where K : IComparable<K>, IEquatable<K>
{
    void Insert(K key, T item);

    void Remove(K key);

    T? Search(K key);

    int Height();

    int Level(K key);

    int Size();
}