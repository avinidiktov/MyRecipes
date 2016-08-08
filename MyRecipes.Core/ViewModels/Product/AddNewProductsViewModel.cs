using System;
using System.Collections.Generic;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MyRecipes.Core.MvvmCrossExtension.Command;
using MyRecipes.Core.MvvmCrossExtension.ViewModels;
using MyRecipes.Core.Services;

namespace MyRecipes.Core.ViewModels.Product
{
    public class AddNewProductsViewModel : ParameterizedViewModel
    {
        private readonly IDbService _dbService;
        public AddNewProductsViewModel(IDbService dbService)
        {
            _dbService = dbService;
        }

        private string _titleNewProduct;

        public string TitleNewProduct
        {
            get { return _titleNewProduct; }
            set { _titleNewProduct = value; RaisePropertyChanged(() => TitleNewProduct); }
        }

        public ICommand AddProductCommand => new MvxRelayCommand(AddNewProduct);

        private void AddNewProduct()
        {
            Random _random = new Random();
            var newProduct = new Model.Product//TODO
            {
                Title = TitleNewProduct,
                Weight = 1,
                ImageUrl = string.Format("http://baconmockup.com/{0}/{0}", _random.Next(20)+80)
            };
            
            _dbService.InsertItem(newProduct);

            TitleNewProduct = "";
            ShowViewModel<ProductsViewModel>();
        }

    }
}
