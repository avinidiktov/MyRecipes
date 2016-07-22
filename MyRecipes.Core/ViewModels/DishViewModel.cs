using System.Collections.Generic;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MyRecipes.Core.Model;
using MyRecipes.Core.MvvmCrossExtension.ViewModels;
using MyRecipes.Core.Services;

namespace MyRecipes.Core.ViewModels
{
    public class DishViewModel :  ParameterizedViewModel
    {
        private readonly IDbService _dBService;


        public DishViewModel(IDbService dBService)
        {
            _dBService = dBService;

            Dishes = new List<Dish>();

            CategoryName = "";
            DishesMessage = "";


        }

        private string _categoryName;
        public string CategoryName {
            get { return _categoryName; }
            set { _categoryName = value; RaisePropertyChanged(()=>CategoryName); }
        }

        private ICollection<Dish> _dishes; 
             
        public ICollection<Dish> Dishes {
            get { return _dishes; }
            set { _dishes = value; RaisePropertyChanged(()=>Dishes); }
        }

        public string _dishesMessage;

        public string DishesMessage
        {
            get { return _dishesMessage; }
            set
            {
                _dishesMessage = value;
                RaisePropertyChanged(() => DishesMessage);
            }
        }


        public override void Init(Parameters parameters)
        {
            Key = parameters.Key;
            CategoryName = _dBService.LoadItem<Category>(int.Parse(Key)).Title;
            UpdateDishesMessage();
        }


        public void UpdateDishesMessage()
        {
            if (Dishes.Count > 0)
            {
                _dishesMessage = $"Блюда в категории {CategoryName} ";
            }
            else
            {
                _dishesMessage = $"Блюда в категории {CategoryName} отсутствуют";
            }
        }


        public ICommand AddDishCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<AddDishViewModel>());
            }
        }


    }
}
