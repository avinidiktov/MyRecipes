using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MyRecipes.Core.MvvmCrossExtension.Command;
using MyRecipes.Core.MvvmCrossExtension.ViewModels;
using MyRecipes.Core.Services;
using MyRecipes.Core.ViewModels.Dish;

namespace MyRecipes.Core.ViewModels.Product
{
    public class ProductsViewModel : ParameterizedViewModel
    {
        private readonly IDbService _dbService;

        public ProductsViewModel(IDbService dbService)
        {
            _dbService = dbService;
            Products = dbService.LoadItems<Model.Product>().ToList();
        }

        private List<Model.Product> _products;
        public List<Model.Product> Products
        {
            get { return _products; }
            set { _products = value; RaisePropertyChanged(() => Products); }
        }


        public ICommand AddProductCommand => new MvxRelayCommand(AddProduct);

        private void AddProduct()
        {
            ShowViewModel<AddNewProductsViewModel>(new Parameters() {Key = this.Key});
        }


        private Model.Product _selectedProduct;
        public Model.Product SelectedProduct
        {
            get { return _selectedProduct; ; }
            set { _selectedProduct = value; RaisePropertyChanged(() => SelectedProduct); }
        }

        public ICommand EditProductCommand => new MvxRelayCommand(SelectingProduct);

        private void SelectingProduct()
        {
            var id = SelectedProduct.Id.ToString();
            ShowViewModel<EditProductViewModel>(new Parameters() { Key = id });
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
