using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;

namespace MyRecipes.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        readonly Type[] _menuItemTypes = {
            typeof(AllProductViewModel),
            typeof(CategoryViewModel)
        };

        public IEnumerable<string> MenuItems { get; private set; } = new[] { "Холодильник", "Категории" };

        public void ShowDefaultMenuItem()
        {
            NavigateTo(0);
        }

        public void NavigateTo(int position)
        {
            ShowViewModel(_menuItemTypes[position]);
        }
    }

    public class MenuItem : Tuple<string, Type>
    {
        public MenuItem(string displayName, Type viewModelType)
            : base(displayName, viewModelType)
        { }

        public string DisplayName => Item1;

        public Type ViewModelType => Item2;
    }
}