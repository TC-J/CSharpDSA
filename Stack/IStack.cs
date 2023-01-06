namespace csdsa;

interface IStack<T>
{
    void Push(T value);

    T? Pop();

    int Size();

    bool Empty();
}