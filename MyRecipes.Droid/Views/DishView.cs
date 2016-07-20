using Android.App;
using MvvmCross.Droid.Views;

namespace MyRecipes.Droid.Views
{
    [Activity(Label = "Dishes", MainLauncher = false)]
    public class DishView:MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Dishs);
        }
    }
}