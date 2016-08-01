using MvvmCross.Core.ViewModels;
using MyRecipes.Core.MvvmCrossExtension.ViewModels;
using MyRecipes.Core.ViewModels.Category;
using MyRecipes.Core.ViewModels.Help;
using MyRecipes.Core.ViewModels.Settings;

namespace MyRecipes.Core.ViewModels.Menu
{
    public class MenuViewModel : BaseViewModel
    {

        public IMvxCommand ShowCategoriesCommand
        {
            get { return new MvxCommand(ShowCategoriesExecuted); }
        }

        private void ShowCategoriesExecuted()
        {
            ShowViewModel<CategoriesViewModel>();
        }



        public IMvxCommand ShowFavoritesDishesCommand
        {
            get { return new MvxCommand(ShowFavoritesDishesExecuted); }
        }

        private void ShowFavoritesDishesExecuted()
        {
            //ShowViewModel<Fav>();
        }


        public IMvxCommand ShowProductsCommand
        {
            get { return new MvxCommand(ShowProductsExecuted); }
        }

        private void ShowProductsExecuted()
        {
            //ShowViewModel<Prod>();
        }




        public IMvxCommand ShowSettingCommand
        {
            get { return new MvxCommand(ShowSettingsExecuted); }
        }

        private void ShowSettingsExecuted()
        {
           // ShowViewModel<SettingsViewModel>();
        }

        public IMvxCommand ShowHelpCommand
        {
            get { return new MvxCommand(ShowHelpExecuted); }
        }

        private void ShowHelpExecuted()
        {
            //ShowViewModel<HelpAndFeedbackViewModel>();
        }

        


    }
}
