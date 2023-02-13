namespace DataFluentAPI.Entities
{
    public interface IRepo<T>
    {
        T Add(T t);
        List<T> GetAll();

        T Delete(string t1,string t2);

        T Update(T t);

        T Get(string t);



    }
}
