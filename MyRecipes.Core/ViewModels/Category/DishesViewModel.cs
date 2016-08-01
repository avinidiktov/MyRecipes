using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MyRecipes.Core.Model;
using MyRecipes.Core.MvvmCrossExtension.ViewModels;
using MyRecipes.Core.Services;

namespace MyRecipes.Core.ViewModels.Category
{
    public class DishesViewModel : ParameterizedViewModel
    {
        private readonly IDbService _dbService;


        public DishesViewModel(IDbService dbService)
        {
            _dbService = dbService;
            CategoryName = "";
        }

        private string _categoryName;
        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; RaisePropertyChanged(() => CategoryName); }
        }

        private List<Dish> _dishes;
        public List<Dish> Dishes
        {
            get { return _dishes; }
            set { _dishes = value; RaisePropertyChanged(() => Dishes); }
        }

        public void Init(Parameters parameters)
        {
            Key = parameters.Key;
        }
    }
}
