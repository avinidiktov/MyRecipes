using System.Collections.Generic;
using System.Linq;
using MvvmCross.Plugins.Sqlite;
using MyRecipes.Core.Model;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;

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



            //CreateCategory();
            //CreateProduct();
            //CreateDish();

            



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

        private void CreateDish()
        {
            
        }

        public void DbUpdate<T>(T obj) where T :class
        {
            _connection.Update(obj);
        }

        public void DbUpdateWithChildren<T>(T obj) where T : class
        {
            _connection.UpdateWithChildren(obj);
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


        /// <summary>
        /// recursive methods
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public T LoadItemWithChildren<T>(int id, bool recursive) where T : class
        {
            return _connection.GetWithChildren<T>(id,recursive);
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

        public void CreateProduct()
        {
            if (LoadItems<Product>().Count == 0)
            {
                InsertItem(new Product()
                {
                    Title = "Картофель",
                    //Weight = (float) 0.500
                });
                InsertItem(new Product()
                {
                    Title = "Морковь",
                    //Weight = (float)0.300
                });
                InsertItem(new Product()
                {
                    Title = "Капуста",
                    //Weight = (float)2.500
                });
                InsertItem(new Product()
                {
                    Title = "Говядина",
                   // Weight = (float)1.500
                });
                InsertItem(new Product()
                {
                    Title = "Свинина",
                    //Weight = (float)1.500
                });

            }
        }



    }
}
