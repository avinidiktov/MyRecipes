using MyRecipes.Core.MvvmCrossExtension.ViewModels;
using MyRecipes.Core.ViewModels.Category;
using MyRecipes.Core.ViewModels.Menu;

namespace MyRecipes.Core.ViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        public void ShowMenu()
        {
            ShowViewModel<CategoriesViewModel>();
            ShowViewModel<MenuViewModel>();
        }


        public void ShowCategories()
        {
            ShowViewModel<CategoriesViewModel>();
        }

        public void Init(object hint)
        {
            // Can perform Vm data retrival here based on any
            // data passed in the hint object

            // ShowViewModel<SomeViewModel>(new { derp: "herp", durr: "derrrrrr" });
            // public class SomeViewModel : MvxViewModel
            // {
            //     public void Init(string derp, string durr)
            //     {
            //     }
            // }
        }

        public override void Start()
        {
            //base.Start();
        }

        
    }
}
