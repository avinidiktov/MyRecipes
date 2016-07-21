using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MyRecipes.Core.Model;

namespace MyRecipes.Core.ViewModels
{
    public class DishViewModel :MvxViewModel
    {
        public DishViewModel()
        {

        }

        private ICollection<Dish> _dishes; 
             
        public ICollection<Dish> Dishes {
            get { return _dishes; }
            set { _dishes = value; RaisePropertyChanged(()=>Dishes); }
        }

    }
}
