﻿using System.Web;
using System.Web.Mvc;
using Week5AuthenticationAuthorization.Utilities;

namespace Week5AuthenticationAuthorization
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
