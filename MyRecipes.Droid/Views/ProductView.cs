using Android.App;
using MvvmCross.Droid.Views;

namespace MyRecipes.Droid.Views
{
    [Activity(Label = "Мои продукты", MainLauncher = false)]
    public class ProductView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            //SetContentView(Resource.Layout.);
        }
    }
}