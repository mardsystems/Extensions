using System;
using System.Threading.Tasks;

namespace Xamarin.Forms
{
    public abstract class ViewModelBase : MvvmHelpers.BaseViewModel, IExceptionHandler
    {
        //protected readonly IViewModelNavigation navigation;

        //bool isBusy = false;

        //public bool IsBusy
        //{
        //    get { return isBusy; }
        //    set { SetProperty(ref isBusy, value); }
        //}

        //string title = string.Empty;

        //public string Title
        //{
        //    get { return title; }
        //    set { SetProperty(ref title, value); }
        //}

        Color backgrounColor = Color.White;

        public Color BackgrounColor
        {
            get { return backgrounColor; }
            set { SetProperty(ref backgrounColor, value); }
        }

        //protected ViewModelBase(IViewModelNavigation navigation)
        //{
        //    this.navigation = navigation;
        //}

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}
