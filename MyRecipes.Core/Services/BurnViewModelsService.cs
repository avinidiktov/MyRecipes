using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MyRecipes.Core.MvvmCrossExtension.ViewModels;
using MyRecipes.Core.ViewModels.Product;

namespace MyRecipes.Core.Services
{
    public static class BurnViewModelsService
    {
        private static readonly IDbService _dbService;

        private static MvxViewModel _burnViewModel;

        public static void addStackLevel(MvxViewModel _parent)
        {
            _burnViewModel = _parent;
        }

        public static void BurnAll()
        {
            if (_burnViewModel != null)
            {
                _burnViewModel = null;
            }
        }


    }
}
