using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Droid.Shared.Attributes;
using MyRecipes.Core.ViewModels.Dish;
using MyRecipes.Core.ViewModels.Main;
using MyRecipes.Droid.Fragments.Base;

namespace MyRecipes.Droid.Fragments.Dish
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("myrecipes.droid.fragments.dish.SelectingProductFragment")]
    public class SelectingProductFragment : BaseFragment<SelectingProductsViewModel>
    {
        private string _oldTitle;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _oldTitle = ((MainActivity)Activity).Title;
            ((MainActivity)Activity).Title = "Выберите продукт";
            ShowHamburgerMenu = true;
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        public override void OnDestroyView()
        {
            ((MainActivity)Activity).Title = _oldTitle;
            base.OnDestroyView();
        }

        public override void OnStop()
        {
            base.OnStop();
        }

        protected override int FragmentId => Resource.Layout.fragment_selecting_product;


    }
}