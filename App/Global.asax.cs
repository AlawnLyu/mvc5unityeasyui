using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using App.Core.App_Start;

namespace App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //BundleTable.EnableOptimizations = true;
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = UnityConfig.GetConfiguredContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            string s = HttpContext.Current.Request.Url.ToString();
            HttpServerUtility server = HttpContext.Current.Server;
            if (server.GetLastError() != null)
            {
                Exception lastError = server.GetLastError();
                //此处记录异常，可以记录到文本或数据库，也可以使用其他日志组件
                //ExceptionHander.WriteException(lastError);

                Application["LastError"] = lastError;
                int statusCode = HttpContext.Current.Response.StatusCode;
                string exceptionOperator = "/SysException/Error";
                try
                {
                    if (!string.IsNullOrEmpty(exceptionOperator))
                    {
                        exceptionOperator = new System.Web.UI.Control().ResolveUrl(exceptionOperator);
                        string url = string.Format("{0}?ErrorUrl={1}", exceptionOperator, server.UrlEncode(s));
                        string script = string.Format("<script language='javascript' type='text/javascript'>window.top.location='{0}'</script>", url);
                        Response.Write(script);
                        Response.End();
                    }
                }
                catch
                {
                }
            }
        }
    }
}
