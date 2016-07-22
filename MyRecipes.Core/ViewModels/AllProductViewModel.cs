using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MyRecipes.Core.Model;
using MyRecipes.Core.MvvmCrossExtension.Command;
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
            Products = dbService.LoadItems<Product>();

            ProductMessage = "";

        }

        private string _productMessage;
        public string ProductMessage {
            get { return _productMessage; }
            set { _productMessage = value; RaisePropertyChanged(() => Products); }
        }


        private ICollection<Product> _products;
        public ICollection<Product> Products {
            get { return _products; }
            set { _products = value; RaisePropertyChanged(() => Products); }
        }

        public ICommand AddNewProductCommand
        {
            get
            {
                return new MvxRelayCommand(() => ShowViewModel<AddNewProductViewModel>());
            }
        }

        public override void Init(Parameters parameters)
        {
           
        }
    }
}
