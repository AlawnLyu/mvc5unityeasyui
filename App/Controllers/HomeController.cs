using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Core;
using App.IBLL;
using App.Models;
using App.Models.Sys;
using Microsoft.Practices.Unity;

namespace App.Controllers
{
    
    public class HomeController : BaseController
    {
        [Dependency]
        public IHomeBLL HomeBll { get; set; }

        [SupportFilter]
        public ActionResult Index()
        {
            ViewBag.UserName = GetUserTrueName();
            return View();
        }

        [HttpPost]
        public JsonResult GetTree(string id)
        {
            if (GetAccount() != null)
            {
                List<SysModule> menu = HomeBll.GetMenuByPersonId(GetUserId(), id);
                var jsonData = (from m in menu
                                select
                                    new
                                    {
                                        id = m.Id,
                                        text = m.Name,
                                        value = m.Url,
                                        showcheck = false,
                                        complete = false,
                                        isexpand = false,
                                        checkstate = 0,
                                        hasChildren = m.IsLast ? false : true,
                                        Icon = m.Iconic
                                    }
                    ).ToArray();
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            return Json("0", JsonRequestBehavior.AllowGet);
        }
    }
}