using System;
using System.Windows.Input;
using MyRecipes.Core.MvvmCrossExtension.Command;
using MyRecipes.Core.MvvmCrossExtension.ViewModels;
using MyRecipes.Core.Services;

namespace MyRecipes.Core.ViewModels.Product
{
    public class EditProductViewModel : ParameterizedViewModel
    {
        private readonly IDbService _dbService;

        public EditProductViewModel(IDbService dbService)
        {
            _dbService = dbService;
        }

        private string _titleEditProduct;
        public string TitleEditProduct
        {
            get { return _titleEditProduct; }
            set { _titleEditProduct = value; RaisePropertyChanged(() => TitleEditProduct); }
        }

        private Model.Product _selectedProduct;

        public Model.Product SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; RaisePropertyChanged(() => SelectedProduct); }
        }



        

        public ICommand EditProductCommand => new MvxRelayCommand(EditProduct);

        private void EditProduct()
        {

            SelectedProduct.Title = TitleEditProduct;
            _dbService.DbUpdate(SelectedProduct);

            TitleEditProduct = "";
            ShowViewModel<ProductsViewModel>();
        }

        public new void Init(Parameters parameters)
        {
            Key = parameters.Key;
            SelectedProduct = _dbService.LoadItem<Model.Product>(int.Parse(Key));
            TitleEditProduct = SelectedProduct.Title;

        }
    }
}
