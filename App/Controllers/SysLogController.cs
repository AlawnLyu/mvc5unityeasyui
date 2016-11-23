using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Common;
using App.Core;
using App.IBLL;
using App.Models.Sys;
using Microsoft.Practices.Unity;

namespace App.Controllers
{
    
    public class SysLogController : BaseController
    {
        [Dependency]
        public ISysLogBLL logBLL { get; set; }
        [SupportFilter]
        //
        // GET: /SysLog/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<SysLogModel> list = logBLL.GetList(ref pager, queryStr);
            var jsonData = new
            {
                total = pager.totalRows,
                rows = (from u in list select u).ToArray()
            };

            return MyJson(jsonData, JsonRequestBehavior.AllowGet,"yyyy-MM-dd HH:mm:ss");
        }

        [SupportFilter]
        public ActionResult Details(string id)
        {
            SysLogModel entity = logBLL.GetById(id);
            return View(entity);
        }
    }
}