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
    
    public class SysSampleController : BaseController
    {
        [Dependency]
        public ISysSampleBLL m_bll { get; set; }

        [SupportFilter]
        // GET: SysSample
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<SysSampleModel> list = m_bll.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new SysSampleModel()
                        {
                            Id = r.Id,
                            Name = r.Name,
                            Age = r.Age,
                            Bir = r.Bir,
                            Photo = r.Photo,
                            Note = r.Note,
                            CreateTime = r.CreateTime
                        }).ToArray()
            };
            return MyJson(json, JsonRequestBehavior.AllowGet, "yyyy-MM-dd HH:mm:ss");
        }

        [SupportFilter]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Create(SysSampleModel model)
        {
            ValidationErrors errors = new ValidationErrors();
            if (ModelState.IsValid)
            {
                if (m_bll.Create(ref errors, model))
                {
                    LogHandler.WriteServiceLog("虚拟用户", "Id:" + model.Id + ",Name:" + model.Name, "成功", "创建", "样例程序");
                    return Json(JsonHandler.CreateMessage(1, "插入成功"), JsonRequestBehavior.AllowGet);
                }
            }
            LogHandler.WriteServiceLog("虚拟用户", "Id:" + model.Id + ",Name:" + model.Name + "," + errors.Error, "失败", "创建", "样例程序");
            return Json(JsonHandler.CreateMessage(0, "插入失败" + errors.Error), JsonRequestBehavior.AllowGet);
        }

        [SupportFilter]
        public ActionResult Edit(string id)
        {
            SysSampleModel entity = m_bll.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(SysSampleModel model)
        {
            ValidationErrors errors = new ValidationErrors();
            if (ModelState.IsValid)
            {
                if (m_bll.Edit(ref errors, model))
                {
                    LogHandler.WriteServiceLog("虚拟用户", "Id:" + model.Id + ",Name:" + model.Name, "成功", "编辑", "样例程序");
                    return Json(JsonHandler.CreateMessage(1, "修改成功"), JsonRequestBehavior.AllowGet);
                }
            }
            LogHandler.WriteServiceLog("虚拟用户", "Id:" + model.Id + ",Name:" + model.Name + "," + errors.Error, "失败", "编辑", "样例程序");
            return Json(JsonHandler.CreateMessage(0, "修改失败" + errors.Error), JsonRequestBehavior.AllowGet);
        }

        [SupportFilter]
        public ActionResult Details(string id)
        {
            SysSampleModel entity = m_bll.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Delete(string id)
        {
            ValidationErrors errors = new ValidationErrors();
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (m_bll.Delete(ref errors, id))
                {
                    LogHandler.WriteServiceLog("虚拟用户", "Id:" + id, "成功", "删除", "样例程序");
                    return Json(JsonHandler.CreateMessage(1, "删除成功"), JsonRequestBehavior.AllowGet);
                }
            }
            LogHandler.WriteServiceLog("虚拟用户", "Id:" + id + "," + errors.Error, "成功", "删除", "样例程序");
            return Json(JsonHandler.CreateMessage(0, "删除失败" + errors.Error), JsonRequestBehavior.AllowGet);
        }
    }
}