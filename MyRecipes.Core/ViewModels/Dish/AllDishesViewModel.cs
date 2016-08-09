using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MyRecipes.Core.MvvmCrossExtension.Command;
using MyRecipes.Core.MvvmCrossExtension.ViewModels;
using MyRecipes.Core.Services;

namespace MyRecipes.Core.ViewModels.Dish
{
    public class AllDishesViewModel : ParameterizedViewModel
    {
        private readonly IDbService _dbService;

        public AllDishesViewModel(IDbService dbService)
        {
            _dbService = dbService;
            Dishes = _dbService.LoadItems<Model.Dish>().ToList();
        }

        private List<Model.Dish> _dishes;
        public List<Model.Dish> Dishes
        {
            get { return _dishes; }
            set { _dishes = value; RaisePropertyChanged(() => Dishes); }
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
            ShowViewModel<EditDishViewModel>(new Parameters() { Key = id});
        }

        //=> ShowViewModel<EditDishViewModel>(new Parameters() {Key = SelectedDish.Id.ToString()}));







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
