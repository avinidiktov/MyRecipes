using MyRecipes.Core.MvvmCrossExtension.ViewModels;
using MyRecipes.Core.Services;

namespace MyRecipes.Core.ViewModels
{
    public class ProductViewModel : ParameterizedViewModel
    {
        private readonly IDbService _dbService;

        public ProductViewModel(IDbService dbService)
        {
            _dbService = dbService;
        }

        public override void Init(Parameters parameters)
        {
            
        }
    }
}
