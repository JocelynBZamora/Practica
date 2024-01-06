using neatBurger.Models.entities;

namespace neatBurger.Repositories
{
    public class Repository <T> where T : class
    {
        public NeatContext Context { get; set; }
        public Repository( NeatContext context)
        {
            Context = context;
        }
        public virtual IEnumerable<T> GetAll() => Context.Set<T>();
        public virtual T? GetById(object id) => Context.Find<T>(id); 
        public virtual void Agregar(T entry)
        {
            Context.Add(entry);
            Context.SaveChanges();
        }
        public virtual void Update(T entry) 
        {
            Context.Update(entry);
            Context.SaveChanges();
        }
        public virtual void Delete(T entry) 
        {
            Context.Remove(entry);
            Context.SaveChanges();
        }
    }
}
