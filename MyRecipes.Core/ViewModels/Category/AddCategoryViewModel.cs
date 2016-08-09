using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MyRecipes.Core.MvvmCrossExtension.Command;
using MyRecipes.Core.MvvmCrossExtension.ViewModels;
using MyRecipes.Core.Services;
using MyRecipes.Core.ViewModels.Product;

namespace MyRecipes.Core.ViewModels.Category
{
    public class AddCategoryViewModel : ParameterizedViewModel
    {
        private readonly IDbService _dbService;

        public AddCategoryViewModel(IDbService dbService)
        {
            _dbService = dbService;
        }


        private string _titleNewCategory;
        public string TitleNewCategory
        {
            get { return _titleNewCategory; }
            set { _titleNewCategory = value; RaisePropertyChanged(() => TitleNewCategory); }
        }


        public ICommand AddCategoryCommand => new MvxRelayCommand(AddNewCategory);
        private void AddNewCategory()
        {
            if (!string.IsNullOrEmpty(TitleNewCategory))
            {
                var newCategory = new Model.Category { Title = TitleNewCategory };
                _dbService.InsertItem(newCategory);
                TitleNewCategory = "";
                ShowViewModel<CategoriesViewModel>();
            }
        }

        public new void Init(Parameters parameters)
        {
            Key = parameters.Key;
        }

    }
}
