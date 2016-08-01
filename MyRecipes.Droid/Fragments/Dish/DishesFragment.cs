using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Droid.Shared.Attributes;
using MyRecipes.Core.ViewModels.Category;
using MyRecipes.Core.ViewModels.Main;
using MyRecipes.Droid.Fragments.Base;

namespace MyRecipes.Droid.Fragments.Dish
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("myrecipes.droid.fragments.dish.DishesFragment")]
    public class DishesFragment : BaseFragment<DishesViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        protected override int FragmentId => Resource.Layout.fragment_dishes;
    }
}