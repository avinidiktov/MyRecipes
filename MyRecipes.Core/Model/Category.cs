using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;


namespace MyRecipes.Core.Model
{
    [Table("Categoty")]
    public class Category : ITitleDomainObject
	{
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Dish> Dishes { get; set; }


	    
	}
}

