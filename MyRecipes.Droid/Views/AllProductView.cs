using Android.App;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views;

namespace MyRecipes.Droid.Views
{
    
    [Activity(Label = "Имеющиеся продукты", MainLauncher = false)]
    public class AllProductView : MvxAppCompatActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.All_Product_Layout);
        }
    }
}