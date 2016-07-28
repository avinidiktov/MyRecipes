using System.Windows.Input;
using MyRecipes.Core.Model;
using MyRecipes.Core.MvvmCrossExtension.Command;
using MyRecipes.Core.MvvmCrossExtension.ViewModels;
using MyRecipes.Core.Services;

namespace MyRecipes.Core.ViewModels
{
    public class AddNewProductViewModel : ParameterizedViewModel
    {
        private readonly IDbService _dbService;

        public AddNewProductViewModel(IDbService dbService)
        {
            _dbService = dbService;
            TitleNewProduct = "";
            NewProduct = new Product();
        }


        public override void Init(Parameters parameters)
        { 
        }

        private string _titleNewProduct;
        public string TitleNewProduct
        {
            get { return _titleNewProduct; }
            set { _titleNewProduct = value; RaisePropertyChanged(()=>TitleNewProduct); }
        }

        private float _weightNewProduct;
        public float WeightNewProduct
        {
            get { return _weightNewProduct; }
            set { _weightNewProduct = value; RaisePropertyChanged(() => WeightNewProduct); }
        }


        private Product _newProduct;
        public Product NewProduct
        {
            get { return _newProduct; }
            set { _newProduct = value; RaisePropertyChanged(()=> NewProduct); }
        }



        public ICommand AddProductCommand
        {
            get
            {
                return new MvxRelayCommand(AddNewProduct);
            }
        }

        private void AddNewProduct()
        {
            if (!string.IsNullOrEmpty(TitleNewProduct))
            {
                NewProduct.Title = TitleNewProduct;
                //NewProduct.Weight = WeightNewProduct;

                _dbService.InsertItem(NewProduct);
                ShowViewModel<AllProductViewModel>();
            }
        }
    }
}
