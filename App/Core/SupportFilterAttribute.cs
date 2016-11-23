using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using App.BLL;
using App.DAL;
using App.Models.Sys;
using System.Web;
using System.Web.Routing;

namespace App.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SupportFilterAttribute : ActionFilterAttribute
    {
        public string ActionName { get; set; }

        private string Area;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //读取请求上下文中的action,controller,id

            //取出区域的控制器，action，id
            string ctlName = filterContext.Controller.ToString();
            string[] routeInfo = ctlName.Split('.');
            string controller = null;
            string action = null;
            string id = null;

            int iAreas = Array.IndexOf(routeInfo, "Areas");
            if (iAreas > 0)
            {
                //取区域及控制器
                Area = routeInfo[iAreas + 1];
            }

            int ctlIndex = Array.IndexOf(routeInfo, "Controllers");
            ctlIndex++;
            controller = routeInfo[ctlIndex].Replace("Controller", "").ToLower();

            //url
            string url = HttpContext.Current.Request.Url.ToString().ToLower();
            string[] urlArray = url.Split('/');
            int urlCtlIndex = Array.IndexOf(urlArray, controller);
            urlCtlIndex++;
            if (urlArray.Count() > urlCtlIndex)
            {
                action = urlArray[urlCtlIndex];
            }
            urlCtlIndex++;
            if (urlArray.Length > urlCtlIndex)
            {
                id = urlArray[urlCtlIndex];
            }
            action = string.IsNullOrEmpty(action) ? "Index" : action;
            int actionIndex = action.IndexOf("?", 0);
            if (actionIndex > 1)
            {
                action = action.Substring(0, actionIndex);
            }
            id = string.IsNullOrEmpty(id) ? "" : id;

            //url路径
            string filePath = HttpContext.Current.Request.FilePath;
            AccountModel account = filterContext.HttpContext.Session["Account"] as AccountModel;
            if (!ValidatePermission(account, controller, action, filePath))
            {
                //HttpContext.Current.Response.Write("你没有操作权限，请联系管理员！");
                //filterContext.Result = new RedirectToRouteResult(
                //     new RouteValueDictionary
                //     {
                //         {"controller", "Account"},
                //         {"action", "Index"},
                //         {"returnUrl", filterContext.HttpContext.Request.RawUrl}
                //     });
                filterContext.Result = new RedirectResult("/Account/Index");
            }
        }

        public bool ValidatePermission(AccountModel account, string controller, string action, string filePath)
        {
            bool bResult = false;
            string actionName = string.IsNullOrEmpty(ActionName) ? action : ActionName;
            if (account != null)
            {
                List<permModel> perm = null;
                //测试当前controller是否已赋权限值，如果没有从
                //如果存在区域,Seesion保存（区域+控制器）
                if (!string.IsNullOrEmpty(Area))
                {
                    controller = Area + "/" + controller;
                }
                perm = (List<permModel>)HttpContext.Current.Session[filePath];
                if (perm == null)
                {
                    using (SysUserBLL userBLL = new SysUserBLL()
                    {
                        sysRightRepository = new SysRightRepository()
                    })
                    {
                        perm = userBLL.GetPermisson(account.Id, controller);//获取当前用户的权限列表
                        HttpContext.Current.Session[filePath] = perm;//获取的劝降放入会话由Controller调用
                    }
                }
                //home yunxu
                if (controller.ToLower() == "home")
                {
                    return true;
                }
                //当用户访问index时，只要权限>0就可以访问
                if (actionName.ToLower() == "index")
                {
                    if (perm.Count > 0)
                    {
                        return true;
                    }
                }
                //查询当前Action 是否有操作权限，大于0表示有，否则没有
                int count = perm.Where(a => a.KeyCode.ToLower() == actionName.ToLower()).Count();
                if (count > 0)
                {
                    bResult = true;
                }
            }
            return bResult;
        }
    }
}