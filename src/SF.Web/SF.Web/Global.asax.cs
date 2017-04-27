﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SF.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //var clientDataTypeValidator = ModelValidatorProviders.Providers.OfType<ClientDataTypeModelValidatorProvider>().FirstOrDefault();
            //if (null != clientDataTypeValidator)
            //{
            //    ModelValidatorProviders.Providers.Remove(clientDataTypeValidator);
            //}
            //ModelValidatorProviders.Providers.Add(new FilterableClientDataTypeModelValidatorProvider());

            DefaultModelBinder.ResourceClassKey = "hint";
        }
    }
}
