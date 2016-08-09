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
    public class FavoritesDishesViewModel : ParameterizedViewModel
    {
        private readonly IDbService _dbService;
        public FavoritesDishesViewModel(IDbService dbService)
        {
            _dbService = dbService;
            FavoritesDishes = _dbService.LoadItems<Model.Dish>()
                .Where(d => d.IsFavorite == true);
        }

        private IEnumerable<Model.Dish> _favoritesDishes;

        public IEnumerable<Model.Dish> FavoritesDishes
        {
            get { return _favoritesDishes; }
            set { _favoritesDishes = value; RaisePropertyChanged(() => FavoritesDishes); }
        }

        public new void Init(Parameters parameters)
        {
            FavoritesDishes = _dbService.LoadItems<Model.Dish>()
                .Where(d => d.IsFavorite == true);
        }

        private Model.Dish _selectedDish;
        public Model.Dish SelectedDish
        {
            get { return _selectedDish; ; }
            set { _selectedDish = value; RaisePropertyChanged(() => SelectedDish); }
        }

        public ICommand SelectedDishCommand => new MvxRelayCommand(SelectingDish);

        private void SelectingDish()
        {
            var id = SelectedDish.Id.ToString();
            ShowViewModel<EditDishViewModel>(new Parameters() { Key = id });
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
            FavoritesDishes = _dbService.LoadItems<Model.Dish>()
                .Where(d => d.IsFavorite == true);
        }

    }
}
