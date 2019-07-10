using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Xamarin.Forms
{
    public static class ViewModelLocator
    {
        public static BindableProperty AutoWireViewModelProperty = BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(AutoWireViewModelProperty, value);
        }

        public static Func<Type, object> Resolve;

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;

            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();

            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.").Replace("Page", "View");

            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;

            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);

            var viewModel = Resolve(viewModelType);

            view.BindingContext = viewModel;
        }
    }
}
