using Android.App;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace MyRecipes.Droid.Views
{
    [Activity(Label = "Мои рецепты")]
    public class CategoryView : MvxAppCompatActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Main_Layout);
        }
    }
}