using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace MyRecipes.Core.Model
{
    [Table("Product")]
    public class Product :ITitleDomainObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }

        public float Weight { get; set; }

        [ManyToMany(typeof(DishProduct),null,null, CascadeOperations = CascadeOperation.All)]
        public List<Dish> Dishes { get; set; }

    }
}
