using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System.ComponentModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        //protected readonly IDialogService DialogService;
        private readonly INavigation navigation;

        public ViewModelBase()
        {
            //DialogService = ViewModelLocator.Instance.Resolve<IDialogService>();
            navigation = ViewModelLocator.Instance.Resolve<INavigation>();
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        //Color backgrounColor = Color.White;

        //public Color BackgrounColor
        //{
        //    get { return backgrounColor; }
        //    set { SetProperty(ref backgrounColor, value); }
        //}

        protected INavigation NavigationService => navigation;

        //protected ViewModelBase(IViewModelNavigation navigation)
        //{
        //    this.navigation = navigation;
        //}

        public virtual Task InitializeAsync(object navigationData) => Task.FromResult(false);
    }
}
