using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms
{
    public static class NavigationExtensions
    {
        private static MasterDetailPage mainPage;

        public static void SetMainPage(MasterDetailPage mainPage)
        {
            NavigationExtensions.mainPage = mainPage;
        }

        public static async Task MainPagePushAsync(this INavigation navigation, Page page)
        {
            //masterDetailPage.IsPresented = false;

            //var detailPage = new NavigationPage(rootPage);

            page.Parent = null;

            //await mainPage.Detail.Navigation.PushAsync(page);

            await navigation.PushAsync(page);
        }
    }
}
