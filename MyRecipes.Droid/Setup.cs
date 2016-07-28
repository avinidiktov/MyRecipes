using System.Collections.Generic;
using System.Reflection;
using Android.Content;

using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Views;
using MvvmCross.Droid.Support.V7.Fragging.Presenter;
using MvvmCross.Platform;
using MyRecipes.Core;


namespace MyRecipes.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }


    }
}