using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MyRecipes.Core.MvvmCrossExtension.Command;
using MyRecipes.Core.MvvmCrossExtension.ViewModels;
using MyRecipes.Core.Services;

namespace MyRecipes.Core.ViewModels.Dish
{
    public class DishesViewModel : ParameterizedViewModel
    {
        private readonly IDbService _dbService;
        public DishesViewModel(IDbService dbService)
        {
            _dbService = dbService;
        }

        private List<Model.Dish> _dishes;

        public List<Model.Dish> Dishes
        {
            get { return _dishes; }
            set { _dishes = value; RaisePropertyChanged(() => Dishes); }
        }



        public ICommand AddDishCommand
        {
            get
            {
                return new MvxRelayCommand(() => ShowViewModel<AddNewDishViewModel>(new Parameters() { Key = this.Key, TypeVM = typeof(DishesViewModel).ToString()}));
            }
        }

        public new void Init(Parameters parameters)
        {
            Key = parameters.Key;
            UpdateCollectionDishes();
        }

        private void UpdateCollectionDishes()
        {
            var category = _dbService.LoadItemWithChildren<Model.Category>(int.Parse(Key), true);
            Dishes = category.Dishes ?? new List<Model.Dish>();
        }


        private bool _isRefreshing;

        public virtual bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                RaisePropertyChanged(() => IsRefreshing);
            }
        }

        public ICommand ReloadCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    IsRefreshing = true;

                    await ReloadData();

                    IsRefreshing = false;
                });
            }
        }

        public virtual async Task ReloadData()
        {
            // By default return a completed Task
            await Task.Delay(5000);
            Dishes = _dbService.LoadItems<Model.Dish>().ToList();

        }








    }
}
