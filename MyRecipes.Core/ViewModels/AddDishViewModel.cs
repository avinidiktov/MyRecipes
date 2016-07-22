using System.Runtime.InteropServices.ComTypes;
using System.Windows.Input;
using MyRecipes.Core.Model;
using MyRecipes.Core.MvvmCrossExtension.Command;
using MyRecipes.Core.MvvmCrossExtension.ViewModels;
using MyRecipes.Core.Services;

namespace MyRecipes.Core.ViewModels
{
    public class AddDishViewModel : ParameterizedViewModel
    {
        private readonly IDbService _dbService ;

        public AddDishViewModel(IDbService dbService)
        {
            _dbService = dbService;
            NewDish = new Dish();
            TitleNewDish = "";
            DescriptionNewDish = "";


        }


        private Dish _newDish;

        public Dish NewDish
        {
            get { return _newDish; }
            set
            {
                _newDish = value;
                RaisePropertyChanged(()=>NewDish);
            }
        }


        private bool _isFavorite;
        public bool IsFavorite {
            get { return _isFavorite; }
            set { _isFavorite = value; RaisePropertyChanged(()=>IsFavorite); }
        }

        private string _titleNewDish;
        public string TitleNewDish
        {
            get { return _titleNewDish; }
            set { _titleNewDish = value; RaisePropertyChanged(() => TitleNewDish); }
        }

        private string _descriptionNewDish;
        public string DescriptionNewDish
        {
            get { return _descriptionNewDish; }
            set { _descriptionNewDish = value; RaisePropertyChanged(() => DescriptionNewDish); }
        }


        public ICommand AddNewDishCommand
        {
            get
            {
                return new MvxRelayCommand(AddNewDish);
            }
        }

        private void AddNewDish()
        {
            if (!string.IsNullOrEmpty(TitleNewDish) && !string.IsNullOrEmpty(DescriptionNewDish))
            {
                NewDish.IsFavorite = IsFavorite;
                NewDish.Title = TitleNewDish;
                NewDish.CookingProcess = DescriptionNewDish;
            }
        }




        public override void Init(Parameters parameters)
        {
            
        }
    }
}
