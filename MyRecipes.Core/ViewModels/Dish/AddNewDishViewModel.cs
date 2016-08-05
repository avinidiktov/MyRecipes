using System.Collections.Generic;
using System.Windows.Input;
using MyRecipes.Core.MvvmCrossExtension.Command;
using MyRecipes.Core.MvvmCrossExtension.ViewModels;
using MyRecipes.Core.Services;
using MyRecipes.Core.ViewModels.Category;

namespace MyRecipes.Core.ViewModels.Dish
{
    public class AddNewDishViewModel : ParameterizedViewModel
    {
        private readonly IDbService _dbService;


        public AddNewDishViewModel(IDbService dbService)
        {
            _dbService = dbService;
            Products = new List<Model.Product>();
            SelectedProducts = new List<Model.Product>();
        }

        private string _categoryName = "";
        public string CategoryName
        {
            get { return _categoryName; }
            set
            {
                _categoryName = value;
                RaisePropertyChanged(() => CategoryName);
            }
        }

        private string _titleNewDish = "";
        public string TitleNewDish
        {
            get { return _titleNewDish; }
            set { _titleNewDish = value; RaisePropertyChanged(() => TitleNewDish); }
        }

        private string _cookingProcessNewDish ="";
        public string CookingProcessNewDish
        {
            get { return _cookingProcessNewDish; }
            set { _cookingProcessNewDish = value; RaisePropertyChanged(() => CookingProcessNewDish); }
        }

        private bool _isFavoriteNewDish = false;
        public bool IsFavoriteNewDish
        {
            get { return _isFavoriteNewDish; }
            set { _isFavoriteNewDish = value; RaisePropertyChanged(()=>IsFavoriteNewDish); }
        }

        private List<Model.Product> _products;
        public List<Model.Product> Products
        {
            get { return _products; }
            set { _products = value; RaisePropertyChanged(() => Products); }
        }

        private List<Model.Product> _selectedProducts;
        public List<Model.Product> SelectedProducts
        {
            get { return _selectedProducts; }
            set { _selectedProducts = value; RaisePropertyChanged(() => SelectedProducts); }
        }

        public ICommand AddNewDishCommand => new MvxRelayCommand(AddNewDish);
        private void AddNewDish()
        {
            if (!string.IsNullOrEmpty(TitleNewDish) && !string.IsNullOrEmpty(CookingProcessNewDish)
                && SelectedProducts.Count != 0)
            {
                var newDish = new Model.Dish
                {

                    Title = TitleNewDish,
                    IsFavorite = IsFavoriteNewDish,
                    CookingProcess = CookingProcessNewDish,
                    Products = SelectedProducts
                };

                _dbService.InsertItem(newDish);

                var category = _dbService.LoadItemWithChildren<Model.Category>(int.Parse(Key), true);
                if (category.Dishes == null)
                {
                    category.Dishes = new List<Model.Dish>();
                }
                category.Dishes.Add(newDish);
                _dbService.DbUpdateWithChildren(category);


                /*for test//--------------------------------------------------------------------------------------
                ///////-----------------------------------------
                TODO--------------------------------------------------------------------------------------------- */

                Products.Clear();
                IsFavoriteNewDish = false;
                TitleNewDish = ""; CookingProcessNewDish = "";

                //////////////////////////////////////////////////////////////////////////////////////////////////////


                ShowViewModel<CategoriesViewModel>();
            }  
        }

        

        public ICommand SelectedProductCommand
        {
            get
            {
                return new MvxRelayCommand(() => ShowViewModel<SelectingProductsViewModel>());
            }
        }



        public new void Init(Parameters parameters)
        {

            //TODO
            ////////////////////////////////////////////////////////////////////////////////////////
            if (parameters.TypeVM == "DishesViewModel")
            {
                CategoryName = _dbService.LoadItem<Model.Category>(int.Parse(Key)).Title;
            }
            if (parameters.TypeVM == "SelectingProductsViewModel")
            {
                var product = new Model.Product();
                Products.Add(_dbService.LoadItem<Model.Product>(int.Parse(Key))); 
            }
            Key = parameters.Key;
            ///////////////////////////////////////////////////////////////////////////////////////
        }

        

    }
}
