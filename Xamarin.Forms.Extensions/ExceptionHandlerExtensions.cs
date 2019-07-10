using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms
{
    public static class ExceptionHandlerExtensions
    {
        public static void HandleException(this IExceptionHandler handler, Exception ex)
        {
            MessagingCenter.Send(handler, "alert", new MessagingCenterAlert
            {
                Title = "Erro",
                Message = $"{ex.Message} \n {ex.StackTrace}",
                Cancel = "OK"
            });
        }
    }
}
