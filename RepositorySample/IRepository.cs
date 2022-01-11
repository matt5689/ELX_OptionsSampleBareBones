using System.Collections.Generic;

namespace RepositorySample
{
    public interface IRepository<T>
    {
        T AddItem(T item);
        IEnumerable<T> All();

        void Save();
    }
}