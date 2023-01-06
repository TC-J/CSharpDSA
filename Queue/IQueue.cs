interface IQueue<T>
{
    void Enqueue(T value);

    T? Dequeue(T value);

    bool IsEmpty();

    int Size();
}