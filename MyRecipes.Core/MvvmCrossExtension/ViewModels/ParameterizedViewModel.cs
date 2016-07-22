using MvvmCross.Core.ViewModels;

namespace MyRecipes.Core.MvvmCrossExtension.ViewModels
{
    public abstract class ParameterizedViewModel : MvxViewModel
    {
        public string _key;

        public string Key {
            get { return _key; }
            set { _key = value;
                RaisePropertyChanged(() => Key);
            }
        }

        public abstract void Init(Parameters parameters);

        public class Parameters
        {
            public string Key { get; set; }
        }

    }
}
