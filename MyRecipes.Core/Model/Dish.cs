using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Core.Model
{
    public  class Dish
    {
        public string Title { get; set; }

        public List<Product> Products { get; set; }

        public string CookingProcess { get; set; }
    }
}
