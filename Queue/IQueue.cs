interface IQueue<T>
{
    void Enqueue(T value);

    T? Dequeue();

    bool IsEmpty();

    int Size();
}