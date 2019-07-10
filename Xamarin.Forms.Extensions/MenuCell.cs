using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms
{
    public class MenuCell : ImageCell
    {
        public static readonly BindableProperty IconProperty = BindableProperty.Create("Icon", typeof(string), typeof(MenuCell), "");

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
    }
}
