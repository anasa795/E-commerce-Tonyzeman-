using Microsoft.EntityFrameworkCore;
using Tonyzeman.Models.Context;
using Tonyzeman.Repository.IReposatory;

namespace Tonyzeman.Repository
{
    public class Repository<T> : IReposatory<T> where T : class
    {


        private readonly TonyzemanContext db;
        public DbSet<T> dbSet;
        public Repository(TonyzemanContext db)
        {
            this.db = db;
            this.dbSet = db.Set<T>();

        }


        //TonyzemanContext db;
        //public Repository(TonyzemanContext db)
        //{
        //        this.db = db;
        //}

        void IReposatory<T>.Add(T entity)
        {
             dbSet.Add(entity);
        }



        T IReposatory<T>.Get(int id)
        {
            return dbSet.Find(id);
        }
        void IReposatory<T>.Delete(int id)
        {
            var entity = ((IReposatory<T>)this).Get(id);
            if (entity != null)
            {

            dbSet.Remove(entity);
            }
        }
        IEnumerable<T> IReposatory<T>.GetAll()
        {
            return dbSet.ToList();  
        }

        void IReposatory<T>.Update(T entity)
        {
            dbSet.Update(entity);
        }

       
    }
}
