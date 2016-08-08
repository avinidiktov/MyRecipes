using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
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
            Products = dbService.LoadItems<Model.Product>().ToList();
            SelectedProducts = new List<Model.Product>();
        }

        private int _categoryId;
        public int CategoryId
        {
            get { return _categoryId; }
            set
            {
                _categoryId = value;
                RaisePropertyChanged(() => CategoryId);
            }
        }

        private int _productId;
        public int ProductId
        {
            get { return _productId; }
            set
            {
                _productId = value;
                RaisePropertyChanged(() => ProductId);
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
            set { _products = _dbService.LoadItems<Model.Product>().ToList(); RaisePropertyChanged(() => Products); }
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

                var category = _dbService.LoadItemWithChildren<Model.Category>(CategoryId, true);
                if (category.Dishes == null)
                {
                    category.Dishes = new List<Model.Dish>();
                }
                category.Dishes.Add(newDish);
                _dbService.DbUpdateWithChildren(category);

                ShowViewModel<DishesViewModel>(new Parameters() { Key = CategoryId.ToString() });

                /*for test//--------------------------------------------------------------------------------------
                ///////-----------------------------------------
                TODO--------------------------------------------------------------------------------------------- */

                SelectedProducts.Clear();
                IsFavoriteNewDish = false;
                TitleNewDish = ""; CookingProcessNewDish = "";
                CategoryId = -1;
                ProductId = -1;
                //////////////////////////////////////////////////////////////////////////////////////////////////////


               
            }  
        }


        private Model.Product _selectedProduct;
        public Model.Product SelectedProduct
        {
            get { return _selectedProduct;; }
            set { _selectedProduct = value; RaisePropertyChanged(() => SelectedProduct);}
        }



        public ICommand SelectedProductCommand
        {
            get
            {
                //return new MvxRelayCommand(() => ShowViewModel<SelectingProductsViewModel>());
                return new MvxRelayCommand(SelectingProducts);
            }
        }

        private void SelectingProducts()
        {
            SelectedProducts.Add(SelectedProduct);
        }


        public new void Init(Parameters parameters)
        {
            Key = parameters.Key;
            CategoryId = _dbService.LoadItem<Model.Category>(int.Parse(Key)).Id;

            ////TODO
            //////////////////////////////////////////////////////////////////////////////////////////
            //if (parameters.TypeVM == "MyRecipes.Core.ViewModels.Dish.DishesViewModel")
            //{
            //    CategoryId = _dbService.LoadItem<Model.Category>(int.Parse(Key)).Id;
            //}
            //if (parameters.TypeVM == "MyRecipes.Core.ViewModels.Dish.SelectingProductsViewModel")
            //{
            //    ProductId = _dbService.LoadItem<Model.Product>(int.Parse(Key)).Id;
            //}

            /////////////////////////////////////////////////////////////////////////////////////////
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
            Products = _dbService.LoadItems<Model.Product>().ToList();
        }






    }
}
