using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MyRecipes.Core.MvvmCrossExtension.Command;
using MyRecipes.Core.MvvmCrossExtension.ViewModels;
using MyRecipes.Core.Services;


namespace MyRecipes.Core.ViewModels.Category
{
    public class CategoriesViewModel : ParameterizedViewModel
    {

        private readonly IDbService _dbService;

        public CategoriesViewModel(IDbService dbService)
        {
            _dbService = dbService;
            Categories = new List<Model.Category>();

            Categories = _dbService.LoadItems<Model.Category>().ToList();
        }


        public List<Model.Category> _categories;
        public List<Model.Category> Categories
        {
            get { return _categories; }
            set { _categories = value; RaisePropertyChanged(() => Categories); }
        }

        private Model.Category _selectedCategory;
        public Model.Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    
                    RaisePropertyChanged(() => SelectedCategory);
                }
            }
        }


        public ICommand CategoryClickedCommand
        {
            get
            {
                var sss = SelectedCategory;
                //return new MvxRelayCommand(() => ShowViewModel<DishesViewModel>());
                return new MvxRelayCommand(() => ShowViewModel<DishesViewModel>(new Parameters() { Key = SelectedCategory.Id.ToString() }));
            }
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

            var rand = new Random();
            Func<char> randChar = () => (char)rand.Next(65, 90);
            Func<int, string> randStr = null;
            randStr = x => (x > 0) ? randStr(--x) + randChar() : "";

            var newItemCount = rand.Next(3);

            //for (var i = 0; i < newItemCount; i++)
            //    Items.Add(new ListItem { Title = "title " + randStr(4) });
        }

    }
}
