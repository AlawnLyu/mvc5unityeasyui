using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Common;
using App.IBLL;
using App.Models.Sys;
using Microsoft.Practices.Unity;

namespace App.Controllers
{
    public class SysExceptionController : BaseController
    {
        [Dependency]
        public ISysExceptionBLL exceptionBLL { get; set; }
        //
        // GET: /SysException/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<SysExceptionModel> list = exceptionBLL.GetList(ref pager, queryStr);
            var jsonData = new
            {
                total = pager.totalRows,
                rows = (from u in list select u).ToArray()
            };
            return MyJson(jsonData, JsonRequestBehavior.AllowGet, "yyyy-MM-dd HH:mm:ss");
        }

        public ActionResult Details(string id)
        {
            SysExceptionModel entity = exceptionBLL.GetById(id);
            return View(entity);
        }

        public ActionResult Error()
        {
            BaseException ex = new BaseException();
            return View(ex);
        }
    }
}