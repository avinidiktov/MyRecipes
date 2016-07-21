using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MyRecipes.Core.Model;
using MyRecipes.Core.Services;

namespace MyRecipes.Core.ViewModels
{
	public class CategoryViewModel : MvxViewModel
	{
        private readonly IDbService _dBService;


        public CategoryViewModel(IDbService dBService)
		{
            _dBService = dBService;
            
            Categories = new List<Category>();

            Categories = dBService.LoadItems<Category>();

            


            
		}

		public ICollection<Category> _categories;

		public ICollection<Category> Categories {
			get { return _categories; }
			set { _categories = value; RaisePropertyChanged(()=>Categories);}
		}


	    public ICollection<Dish> _favorites;

	    public ICollection<Dish> Favorites
	    {
	        get { return _favorites; }
	        set { _favorites = value; RaisePropertyChanged(()=>Favorites); }
	    }
	}
}



