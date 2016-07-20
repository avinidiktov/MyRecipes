using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MyRecipes.Core.Model;


namespace MyRecipes.Core
{
	public class CategoryViewModel : MvxViewModel
	{
		public CategoryViewModel()
		{
			Categories = new List<Category>() {
				new Category{
				Title = "Супы",
				Dishes = new List<Dish>(){
				    new Dish(){
					    Title = "Борщ",
					    CookingProcess = "берем то то то ....",
                        IsFavorites = true,
					    Products = new List<Product>
					    {
						    new Product()
						    {
							    Title = "Капуста",
							    Weight = (float) 0.500
						    },
						    new Product()
						    {
							    Title = "Картошка",
							    Weight = (float) 0.800
						    }
					    }
				    },
				    new Dish()
				    {
					    Title = "Щи",
					    CookingProcess = "берем что то версия 2",
                        IsFavorites = false,
					    Products = new List<Product>
					    {
						    new Product()
						    {
							    Title = "Вода",
							    Weight = (float) 0.500
						    },
						    new Product()
						    {
							    Title = "Мясо",
							    Weight = (float) 0.800
						    }
					    }
				    }
					}
				},
				new Category{
					Title = "Салаты",
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Title = "Оливье",
                            CookingProcess = "нарезать то то то",
                            IsFavorites = true,
                            Products = new List<Product>()
                            {
                                new Product()
                                {
                                    Title = "Картошка",
                                    Weight = (float) 0.800
                                },
                                new Product()
                                {
                                    Title = "Колбаса",
                                    Weight = (float) 1.0
                                }
                            }
                        }
                    }

				},
				new Category{
					Title = "Напитки",
                    Dishes = new List<Dish>()
				}
			};

            Favorites = new List<Dish>();

		    for (int i = 0; i < Categories.Count; i++)
		    {
		        for (int j = 0; j < Categories[i].Dishes.Count; j++)
		        {
		            if (Categories[i].Dishes[j].IsFavorites)
		            {
		                Favorites.Add(Categories[i].Dishes[j]);
		            }
		        }
		    }
		}

		public List<Category> _categories;

		public List<Category> Categories {
			get { return _categories; }
			set { _categories = value; RaisePropertyChanged(()=>Categories);}
		}


	    public List<Dish> _favorites;

	    public List<Dish> Favorites
	    {
	        get { return _favorites; }
	        set { _favorites = value; RaisePropertyChanged(()=>Favorites); }
	    }
	}
}



