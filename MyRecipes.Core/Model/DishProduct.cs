using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;


namespace MyRecipes.Core.Model
{
    [Table("DishProduct")]
    public class DishProduct 
    {
        [ForeignKey(typeof(Dish))]
        public int DishId { get; set; }

        [ForeignKey(typeof(Product))]
        public int ProductId { get; set; }


    }
}
