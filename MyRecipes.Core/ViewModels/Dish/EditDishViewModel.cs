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
    public class EditDishViewModel : ParameterizedViewModel
    {
        private readonly IDbService _dbService;

        public EditDishViewModel(IDbService dbService)
        {
            _dbService = dbService;
            Products = dbService.LoadItems<Model.Product>().ToList();
            SelectedProducts = new List<Model.Product>();
        }

        private Model.Dish _selectedDish;

        public Model.Dish SelectedDish
        {
            get { return _selectedDish; }
            set { _selectedDish = value; RaisePropertyChanged(() => SelectedProduct); }
        }



        private string _titleEditDish = "";
        public string TitleEditDish
        {
            get { return _titleEditDish; }
            set { _titleEditDish = value; RaisePropertyChanged(() => TitleEditDish); }
        }

        private string _cookingProcessEditDish = "";
        public string CookingProcessEditDish
        {
            get { return _cookingProcessEditDish; }
            set { _cookingProcessEditDish = value; RaisePropertyChanged(() => CookingProcessEditDish); }
        }

        private bool _isFavoriteEditDish = false;
        public bool IsFavoriteEditDish
        {
            get { return _isFavoriteEditDish; }
            set { _isFavoriteEditDish = value; RaisePropertyChanged(() => IsFavoriteEditDish); }
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



        public ICommand EditDishCommand => new MvxRelayCommand(EditDish);
        private void EditDish()
        {
            if (!string.IsNullOrEmpty(TitleEditDish) && !string.IsNullOrEmpty(CookingProcessEditDish)
                && SelectedProducts.Count != 0)
            {
                SelectedDish.Title = TitleEditDish;
                SelectedDish.CookingProcess = CookingProcessEditDish;
                SelectedDish.IsFavorite = IsFavoriteEditDish;
                SelectedDish.Products = SelectedProducts;


                
                _dbService.DbUpdateWithChildren(SelectedDish);
                //var aa = _dbService.LoadItemWithChildren<Model.Dish>(SelectedDish.Id, true);
                

                ShowViewModel<AllDishesViewModel>();

            }
        }


        public ICommand DeleteDishCommand => new MvxRelayCommand(DeleteDish);
        private void DeleteDish()
        {
            _dbService.DeleteItem(SelectedDish, false);
            ShowViewModel<AllDishesViewModel>();

        }


        private Model.Product _selectedProduct;
        public Model.Product SelectedProduct
        {
            get { return _selectedProduct; ; }
            set { _selectedProduct = value; RaisePropertyChanged(() => SelectedProduct); }
        }



        public ICommand SelectedProductCommand => new MvxRelayCommand(SelectingProducts);
        private void SelectingProducts()
        {
            if (SelectedProducts.Count == 0)
            {
                SelectedProducts.Add(SelectedProduct);
                return;
            }

            if (!SelectedProducts.Contains(SelectedProduct))
            {
                SelectedProducts.Add(SelectedProduct);
            }
            else
            {
                SelectedProducts.RemoveAll(s => s == SelectedProduct);
            }

        }


        public new void Init(Parameters parameters)
        {
            Key = parameters.Key;
            SelectedDish = _dbService.LoadItemWithChildren<Model.Dish>(int.Parse(Key), true);
            
            TitleEditDish = SelectedDish.Title;
            CookingProcessEditDish = SelectedDish.CookingProcess;
            IsFavoriteEditDish = SelectedDish.IsFavorite;
            SelectedProducts = SelectedDish.Products;

            Products = _dbService.LoadItems<Model.Product>().ToList();
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