using System.Collections.Generic;
using System.Linq;
using MvvmCross.Plugins.Sqlite;
using MyRecipes.Core.Model;
using SQLite.Net;

namespace MyRecipes.Core.Services
{
    public class DbService : IDbService
    {
        private readonly SQLiteConnection _connection;

        public DbService(IMvxSqliteConnectionFactory factory)
        {

            //CREATE DB
            _connection = factory.GetConnection("data.dat");
            _connection.CreateTable<Category>();
            _connection.CreateTable<Dish>();
            _connection.CreateTable<DishProduct>();
            _connection.CreateTable<Product>();



            CreateCategory();



            //Clear db
            /*
            _connection.DropTable<Category>();
            _connection.DropTable<Dish>();
            _connection.DropTable<DishProduct>();
            _connection.DropTable<Product>();
           
            _connection.Execute("delete from Category");
            _connection.Execute("delete from Dish");
            _connection.Execute("delete from DishProduct");
            _connection.Execute("delete from Product");
            */






        }

        public T LoadItem <T>(int id) where T : class
        {
            return _connection.Get<T>(id);
        }

        public void InsertItem<T>(T item) where T : class
        {
            _connection.Insert(item);
        }

        public ICollection<T> LoadItems<T>() where T : class
        {
            return _connection.Table<T>().ToList();
        }


        public void CreateCategory()
        {
            if (LoadItems<Category>().Count == 0)
            {
                InsertItem(new Category()
                {
                    Title = "Супы",
                    Dishes = new List<Dish>()
                });

                InsertItem(new Category()
                {
                    Title = "Салаты",
                    Dishes = new List<Dish>()
                });

                InsertItem(new Category()
                {
                    Title = "Напитки",
                    Dishes = new List<Dish>()
                });
                InsertItem(new Category()
                {
                    Title = "Гарниры",
                    Dishes = new List<Dish>()
                });
                InsertItem(new Category()
                {
                    Title = "Десерты",
                    Dishes = new List<Dish>()
                });
            }
        }



    }
}
