using System;
using System.Collections.Generic;
using System.Web;

namespace WelareTshirt
{
    public class HTMLHelper
    {
        public static void jsAlertAndRedirect(System.Web.UI.Page instance, string Message, string url)
        {
            instance.Response.Write(@"<script language='javascript'>alert('" + Message + "');document.location.href='" + url + "'; </script>");
        }
    }
}