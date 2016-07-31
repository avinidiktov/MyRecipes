using MvvmCross.Core.ViewModels;
using MyRecipes.Core.ViewModels.Base;

namespace MyRecipes.Core.ViewModels.Home
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            //Recycler = new RecyclerViewModel();
        }

        /// <summary>Gets the recycler.</summary>
        /// <value>The recycler.</value>
        //public RecyclerViewModel Recycler { get; private set; }

        public MvxCommand GoToInfoCommand
        {
            get { return new MvxCommand(() => ShowViewModel<HomeViewModel>()); }
        }

    }
}
