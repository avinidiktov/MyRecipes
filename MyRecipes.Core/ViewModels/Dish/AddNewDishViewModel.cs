using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MyRecipes.Core.Extensions;
using MyRecipes.Core.MvvmCrossExtension.Command;
using MyRecipes.Core.MvvmCrossExtension.ViewModels;
using MyRecipes.Core.Services;

namespace MyRecipes.Core.ViewModels.Dish
{
    public class AddNewDishViewModel : ParameterizedViewModel
    {
        private readonly IDbService _dbService;


        public AddNewDishViewModel(IDbService dbService)
        {
            _dbService = dbService;

            var products = _dbService.LoadItems<Model.Product>().ToList();
            Products = new List<ProductExtension>();
            SelectedProducts = new List<Model.Product>();
            ConverterCollection(Products, products);
        }


        private void ConverterCollection(List<ProductExtension> productsExtension, List<Model.Product> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                var product = new ProductExtension()
                {
                    Id = products[i].Id,
                    Title = products[i].Title,
                    Dishes = products[i].Dishes,
                    ImageUrl = products[i].ImageUrl,
                    IsSelected = false,
                    Weight = products[i].Weight

                };
                productsExtension.Add(product);
            }

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


        private List<ProductExtension> _products;
        public List<ProductExtension> Products
        {
            get { return _products; }
            set { _products = value;RaisePropertyChanged(() => Products); }
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
                _dbService.DbUpdateWithChildren(newDish);

                //var aa = _dbService.LoadItemWithChildren<Model.Dish>(newDish.Id, true);
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
                Products.Clear();

                ConverterCollection(Products, _dbService.LoadItems<Model.Product>().ToList());
                IsFavoriteNewDish = false;
                TitleNewDish = ""; CookingProcessNewDish = "";
                CategoryId = -1;
                ProductId = -1;
                //////////////////////////////////////////////////////////////////////////////////////////////////////
            }  
        }


        private ProductExtension _selectedProduct;
        public ProductExtension SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; RaisePropertyChanged(() => SelectedProduct);}
        }

        private int findProduct()
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (SelectedProduct.Id == Products[i].Id)
                {
                    return i;
                }
            }
            return -1;
        }


        public ICommand SelectedProductCommand => new MvxRelayCommand(SelectingProducts);
        private void SelectingProducts()
        {
            var index = findProduct();
            if (SelectedProducts.Count == 0)
            {
                SelectedProducts.Add(SelectedProduct);
                Products[index].IsSelected = true;
                return;
            }

            if (!SelectedProducts.Contains(SelectedProduct))
            {
                SelectedProducts.Add(SelectedProduct);
                Products[index].IsSelected = true;
            }
            else
            {
                SelectedProducts.RemoveAll(s => s == SelectedProduct);
                Products[index].IsSelected = false;
            }

        }


        public new void Init(Parameters parameters)
        {
            Key = parameters.Key;
            CategoryId = _dbService.LoadItem<Model.Category>(int.Parse(Key)).Id;

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
            Products.Clear();
            var products = _dbService.LoadItems<Model.Product>().ToList();
            ConverterCollection(Products, products);
        }






    }
}
