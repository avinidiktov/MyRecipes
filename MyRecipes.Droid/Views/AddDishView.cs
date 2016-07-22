using Android.App;
using MvvmCross.Droid.Views;

namespace MyRecipes.Droid.Views
{
    [Activity(Label = "Добавление блюда", MainLauncher = false)]
    public class AddDishView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Add_Dish_Layout);
        }

    }
}