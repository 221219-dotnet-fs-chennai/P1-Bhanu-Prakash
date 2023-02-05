namespace DataFluentAPI
{
    public interface IRepo<T>
    {
        T Add(T t);
        List<T> GetAll();

    }
}
