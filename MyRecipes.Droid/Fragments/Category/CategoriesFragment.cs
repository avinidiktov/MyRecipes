using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MyRecipes.Core.ViewModels.Category;
using MyRecipes.Core.ViewModels.Main;
using MyRecipes.Droid.Fragments.Base;

namespace MyRecipes.Droid.Fragments.Category
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("myrecipes.droid.fragments.category.CategoriesFragment")]
    public class CategoriesFragment : BaseFragment<CategoriesViewModel>
    {
        //private IDisposable _itemSelectedToken;


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;
            return base.OnCreateView(inflater, container, savedInstanceState);

            //var recyclerView = view.FindViewById<MvxRecyclerView>(Resource.Id.my_recycler_view);
            //if (recyclerView != null)
            //{
            //    recyclerView.HasFixedSize = true;
            //    var layoutManager = new LinearLayoutManager(Activity);
            //    recyclerView.SetLayoutManager(layoutManager);
            //}


            //var swipeToRefresh = view.FindViewById<MvxSwipeRefreshLayout>(Resource.Id.refresher);
            //var appBar = Activity.FindViewById<AppBarLayout>(Resource.Id.appbar);
            //if (appBar != null)
            //{
            //    appBar.OffsetChanged += (sender, args) => swipeToRefresh.Enabled = args.VerticalOffset == 0;
            //}

            //return view;
        }


        //public override void OnDestroyView()
        //{
        //    base.OnDestroyView();
        //    _itemSelectedToken.Dispose();
        //    _itemSelectedToken = null;
        //}

        protected override int FragmentId => Resource.Layout.fragment_categories;
    }
}