using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        //


        public T LoadItem <T>(int id) where T : class
        {
            return _connection.Table<T>().LastOrDefault();
        }

        public void InsertItem<T>(T item) where T : class
        {
            _connection.Insert(item);
        }

        public IEnumerable LoadItems<T>() where T : class
        {
            return _connection.Table<T>();
        }
    }
}
