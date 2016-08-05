using MvvmCross.Core.ViewModels;

namespace MyRecipes.Core.MvvmCrossExtension.ViewModels
{
    public class ParameterizedViewModel : MvxViewModel
    {
        public ParameterizedViewModel()
        {
            
        }
        public string _key;

        public string Key {
            get { return _key; }
            set { _key = value;
                RaisePropertyChanged(() => Key);
            }
        }

        public string _typeVM;

        public string TypeVM
        {
            get { return _typeVM; }
            set
            {
                _typeVM = value;
                RaisePropertyChanged(() => TypeVM);
            }
        }


        public void Init(Parameters parameters)
        {
        }

        public class Parameters
        {
            public string Key { get; set; }
            public string TypeVM { get; set; }
        }

    }
}
