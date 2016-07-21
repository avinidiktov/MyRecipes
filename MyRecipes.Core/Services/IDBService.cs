using System.Collections.Generic;

namespace MyRecipes.Core.Services
{
    public interface IDbService
    {
        T LoadItem<T>(int id) where T : class;

        void InsertItem<T>(T item) where T : class;

        ICollection<T> LoadItems<T>() where T : class;
    }
}
