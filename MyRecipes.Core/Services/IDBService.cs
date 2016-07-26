using System.Collections.Generic;

namespace MyRecipes.Core.Services
{
    public interface IDbService
    {
        T LoadItem<T>(int id) where T : class;

        void InsertItem<T>(T item) where T : class;

        ICollection<T> LoadItems<T>() where T : class;

        void DbUpdate<T>(T obj) where T : class;

        T LoadItemWithChildren<T>(int id, bool recursive) where T : class;
        void DbUpdateWithChildren<T>(T obj) where T : class;
    }
}
