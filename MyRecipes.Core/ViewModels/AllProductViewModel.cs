using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MyRecipes.Core.Model;
using MyRecipes.Core.MvvmCrossExtension.ViewModels;
using MyRecipes.Core.Services;

namespace MyRecipes.Core.ViewModels
{
    public class AllProductViewModel : ParameterizedViewModel
    {

        private readonly IDbService _dbService;
        public AllProductViewModel(IDbService dbService)
        {
            _dbService = dbService;

            Products = new List<Product>();
            Products = dbService.LoadItems<Product>().ToList();

            ProductMessage = "";

        }

        private string _productMessage;
        public string ProductMessage {
            get { return _productMessage; }
            set { _productMessage = value; RaisePropertyChanged(() => Products); }
        }


        private List<Product> _products;
        public List<Product> Products {
            get { return _products; }
            set { _products = value; RaisePropertyChanged(() => Products); }
        }

        public ICommand AddNewProductCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<AddNewProductViewModel>());
            }
        }

        public override void Init(Parameters parameters)
        {
           
        }
    }
}
