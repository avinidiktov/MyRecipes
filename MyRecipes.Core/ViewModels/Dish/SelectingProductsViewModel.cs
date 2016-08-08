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
    public class SelectingProductsViewModel : ParameterizedViewModel
    {
        private readonly IDbService _dbService;
        public SelectingProductsViewModel(IDbService dbService)
        {
            _dbService = dbService;
            Products = _dbService.LoadItems<Model.Product>().ToList();

        }


        private List<Model.Product> _products;
        public List<Model.Product> Products
        {
            get { return _products; }
            set { _products = value; RaisePropertyChanged(() => Products); }
        }

        private Model.Product _selectedProduct;

        public Model.Product SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; RaisePropertyChanged(() => SelectedProduct); }
        }

        public new void Init(Parameters parameters)
        {
            Key = parameters.Key;
        }
        public ICommand SelectingProductCommand => new MvxRelayCommand(SendProductToDish);

        private void SendProductToDish()
        {
            Key = SelectedProduct.Id.ToString();
            TypeVM = this.GetType().ToString();
            ShowViewModel<AddNewDishViewModel>(new Parameters() { Key = this.Key, TypeVM = typeof(SelectingProductsViewModel).ToString()});
        }

//() => ShowViewModel<DishesViewModel>(new Parameters() { Key = this.Key, TypeVM = this.GetType().ToString()}));


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
