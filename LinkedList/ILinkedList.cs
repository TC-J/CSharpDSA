namespace csdsa;
interface ILinkedList<T>
where T : IComparable
{

    void Prepend(T value);

    void Append(T value);

    bool Insert(uint index, T value);

    int Size();

    bool IsEmpty();

    T? Get(uint index);

    void Delete(uint index);

    int Search(T value);

}