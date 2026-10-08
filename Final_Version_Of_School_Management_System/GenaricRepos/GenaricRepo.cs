using Final_Version_Of_School_Management_System.Models;

namespace Final_Version_Of_School_Management_System.GenaricRepos
{
    public class GenaricRepo<T> : IGenaricRepo<T> where T : class
    {
        private readonly Context c;
        public GenaricRepo(Context c)
        {
            this.c = c;
        }
        public void Add(T item)
        {
            c.Set<T>().Add(item);
        }

        

        public void Delete(T item)
        {
        c.Set<T>().Remove(item);
        }

        public List<T> GetAll()
        {
            return c.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return c.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            c.Set<T>().Update(item);
        }
    
    }
}
