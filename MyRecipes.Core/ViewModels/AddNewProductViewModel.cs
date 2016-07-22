using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRecipes.Core.MvvmCrossExtension.ViewModels;
using MyRecipes.Core.Services;

namespace MyRecipes.Core.ViewModels
{
    public class AddNewProductViewModel : ParameterizedViewModel
    {
        private readonly DbService _dbService;

        public AddNewProductViewModel(DbService dbService)
        {
            _dbService = dbService;
        }




        public override void Init(Parameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
