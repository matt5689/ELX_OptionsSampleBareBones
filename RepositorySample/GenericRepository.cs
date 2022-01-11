using System.Collections.Generic;
using System.Linq;

namespace RepositorySample
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected DataContext context;

        public GenericRepository(DataContext context)
        {
            this.context = context;
        }

        public virtual T AddItem(T item)
        {
            return context.Add(item).Entity;

        }

        public virtual T AddOneToLastSimpleClassItemValue(T item)
        {
            return context.Update(item).Entity;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public IEnumerable<T> All()
        {
            return context.Set<T>().ToList();
        }
    }
}