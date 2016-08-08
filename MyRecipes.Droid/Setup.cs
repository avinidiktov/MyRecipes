using Android.Content;
using System.Collections.Generic;
using System.Reflection;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Droid.Shared.Presenter;
using MvvmCross.Platform.Plugins;
using MvvmCross.Plugins.DownloadCache;
using MyRecipes.Droid.Services;


namespace MyRecipes.Droid {
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IEnumerable<Assembly> AndroidViewAssemblies => new List<Assembly>(base.AndroidViewAssemblies)
        {
            typeof(Android.Support.Design.Widget.NavigationView).Assembly,
            typeof(Android.Support.Design.Widget.FloatingActionButton).Assembly,
            typeof(Android.Support.V7.Widget.Toolbar).Assembly,
            typeof(Android.Support.V4.Widget.DrawerLayout).Assembly,
            typeof(Android.Support.V4.View.ViewPager).Assembly,
            typeof(MvvmCross.Droid.Support.V7.RecyclerView.MvxRecyclerView).Assembly
        };
        /// <summary>
        /// This is very important to override. The default view presenter does not know how to show fragments!
        /// </summary>
        /// 
        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var mvxFragmentsPresenter = new MvxFragmentsPresenter(AndroidViewAssemblies);
            Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(mvxFragmentsPresenter);

            ////add a presentation hint handler to listen for pop to root
            //mvxFragmentsPresenter.AddPresentationHintHandler<MvxPanelPopToRootPresentationHint>(hint =>
            //{
            //    var activity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
            //    var fragmentActivity = activity as Android.Support.V4.App.FragmentActivity;

            //    for (int i = 0; i < fragmentActivity.SupportFragmentManager.BackStackEntryCount; i++)
            //    {
            //        fragmentActivity.SupportFragmentManager.PopBackStack();
            //    }
            //    return true;
            //});
            ////register the presentation hint to pop to root
            ////picked up in the third view model
            //Mvx.RegisterSingleton<MvxPresentationHint>(() => new MvxPanelPopToRootPresentationHint());
            return mvxFragmentsPresenter;
        }


        /* --- https://github.com/MvvmCross/MvvmCross-Plugins/issues/119 */
        protected override void AddPluginsLoaders(MvxLoaderPluginRegistry registry)
        {
            registry.Register<MvvmCross.Plugins.DownloadCache.PluginLoader, MvvmCross.Plugins.DownloadCache.Droid.Plugin>();
            registry.Register<MvvmCross.Plugins.File.PluginLoader, MvvmCross.Plugins.File.Droid.Plugin>();
            base.AddPluginsLoaders(registry);
        }

        protected override void InitializeLastChance()
        {

            base.InitializeLastChance();
            MvvmCross.Plugins.File.PluginLoader.Instance.EnsureLoaded();
            MvvmCross.Plugins.Json.PluginLoader.Instance.EnsureLoaded();
            PluginLoader.Instance.EnsureLoaded();
        }
        /*--------------------------------------------------------------*/



        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            Mvx.RegisterSingleton<IDialogService>(() => new DialogService());
        }

    }
}
 