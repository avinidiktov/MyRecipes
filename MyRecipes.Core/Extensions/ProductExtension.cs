using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRecipes.Core.Model;

namespace MyRecipes.Core.Extensions
{
    public class ProductExtension : Product
    {
        public bool IsSelected { get; set; }
    }
}
