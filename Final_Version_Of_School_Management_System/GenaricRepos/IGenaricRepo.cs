namespace Final_Version_Of_School_Management_System.GenaricRepos
{
    public interface IGenaricRepo<T> where T : class
    {
        List<T> GetAll();
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        T GetById(int id);
    }
}
