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

        private List<Dish> _dishes; 
             
        public List<Dish> Dishes {
            get { return _dishes; }
            set { _dishes = value; RaisePropertyChanged(()=>Dishes); }
        }

    }
}
