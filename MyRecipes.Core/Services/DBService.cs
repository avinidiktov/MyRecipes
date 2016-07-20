using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Plugins.Sqlite;
using MyRecipes.Core.Model;
using SQLite.Net;

namespace MyRecipes.Core.Services
{
    public class DBService : IDBService
    {
        private readonly SQLiteConnection _connection;

        public DBService(IMvxSqliteConnectionFactory factory)
        {

            //CREATE DB
            _connection = factory.GetConnection("data.dat");
            _connection.CreateTable<Category>();
            _connection.CreateTable<Dish>();
            _connection.CreateTable<DishProduct>();
            _connection.CreateTable<Product>();
        }

        //






    }
}
