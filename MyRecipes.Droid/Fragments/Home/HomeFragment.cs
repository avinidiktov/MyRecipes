using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Droid.Shared.Attributes;
using MyRecipes.Core.ViewModels.Base;
using MyRecipes.Core.ViewModels.Home;
using MyRecipes.Droid.Fragments.Base;

namespace MyRecipes.Droid.Fragments.Home
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("myrecipes.droid.fragments.home.HomeFragment")]
    public class HomeFragment : BaseFragment<HomeViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        protected override int FragmentId => Resource.Layout.fragment_home;
    }
}