using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using MyRecipes.Core.Model;
using MyRecipes.Core.MvvmCrossExtension.Command;
using MyRecipes.Core.MvvmCrossExtension.ViewModels;
using MyRecipes.Core.Services;

namespace MyRecipes.Core.ViewModels
{
	public class CategoryViewModel : ParameterizedViewModel
    {
        private readonly IDbService _dBService;

        public CategoryViewModel(IDbService dBService)
		{
            _dBService = dBService;
            
            Categories = new List<Category>();
            Categories = _dBService.LoadItems<Category>().ToList();


            Favorites = new List<Dish>();
            Favorites = _dBService.LoadItems<Dish>().Where(d => d.IsFavorite).ToList();

            if (Favorites.Count == 0)
            {
                FavoritesMessage = "Список избраного отсутствует";
            }
            else
            {
                FavoritesMessage = "";
            }

            if (Categories.Count == 0)
            {
                CategoriesMessage = "Список категорий отсутствует";
            }
            else
            {
                CategoriesMessage = "";
            }
        }


		public List<Category> _categories;
		public List<Category> Categories {
			get { return _categories; }
			set { _categories = value; RaisePropertyChanged(()=>Categories);}
		}


	    public List<Dish> _favorites;
	    public List<Dish> Favorites
	    {
	        get { return _favorites; }
	        set { _favorites = value; RaisePropertyChanged(()=>Favorites); }
	    }


	    private string _favoritesMessage;
        public string FavoritesMessage {
	        get { return _favoritesMessage; }
	        set { _favoritesMessage = value;
	            RaisePropertyChanged(() => FavoritesMessage);
	        }
	    }


        private string _categoriesMessage;
        public string CategoriesMessage
        {
            get { return _categoriesMessage; }
            set
            {
                _categoriesMessage = value;
                RaisePropertyChanged(() => CategoriesMessage);
            }
        }


        public ICommand CategoryClickedCommand
        {
            get
            {
                return new MvxRelayCommand(() => ShowViewModel<DishViewModel>(new Parameters() {Key = SelectedCategory.Id.ToString()}));
            }
        }


	    


	    private Category _selectedCategory;
	    public Category SelectedCategory
	    {
            get { return _selectedCategory; }
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    //UpdateItemSelections();    // Move this to OnItemSelected()
                    RaisePropertyChanged(() => SelectedCategory);
                }
            }
        }

	    public override void Init(Parameters parameters)
	    {
            Key = parameters.Key;
        }

        public ICommand AddCategoryCommand
        {
            get
            {
                return new MvxRelayCommand(() => ShowViewModel<AddCategoryViewModel>());
            }
        }

        public ICommand ShowAllProductCommand
        {
            get
            {
                return new MvxRelayCommand(() => ShowViewModel<AllProductViewModel>());
            }
        }




    }
}



