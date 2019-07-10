using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms
{
    public static class MasterDetailPageExtensions
    {
        private static MasterDetailPage mainPage;

        public static void SetMainPage(MasterDetailPage mainPage)
        {
            MasterDetailPageExtensions.mainPage = mainPage;
        }

        public static void Show(this MasterDetailPage masterDetailPage, Page page)
        {
            //masterDetailPage.IsPresented = false;

            //var detailPage = new NavigationPage(rootPage);

            mainPage.Detail = page;
        }
    }
}
