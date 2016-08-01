using System;
using MvvmCross.Core.ViewModels;
using MyRecipes.Core.MvvmCrossExtension.ViewModels;
using MyRecipes.Core.Services;

namespace MyRecipes.Core.ViewModels.Category
{
    class AddCategoryViewModel : ParameterizedViewModel
    {
        private readonly IDbService _dbService;

        public AddCategoryViewModel(IDbService dbService)
        {
            _dbService = dbService;


        }
    }
}
