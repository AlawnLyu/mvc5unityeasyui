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
    public class SysStructController : BaseController
    {
        [Dependency]
        public ISysStructBLL m_BLL { get; set; }
        ValidationErrors errors = new ValidationErrors();

        [SupportFilter]
        public ActionResult Index()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }

        [HttpPost]
        [SupportFilter(ActionName = "Index")]
        public JsonResult GetList(string id)
        {
            if (id == null)
            {
                id = "0";
            }
            List<SysStructModel> list = m_BLL.GetList(id);
            var json = (from r in list
                        select new SysStructModel()
                        {
                            Id = r.Id,
                            Name = r.Name,
                            ParentId = r.ParentId,
                            Sort = r.Sort,
                            Higher = r.Higher,
                            Enable = r.Enable,
                            Remark = r.Remark,
                            CreateTime = r.CreateTime,
                            state = (m_BLL.GetList(r.Id).Count > 0) ? "closed" : "open"
                        });
            return MyJson(json);
        }

        #region 创建
        [SupportFilter]
        public ActionResult Create(string id)
        {
            ViewBag.Perm = GetPermission();
            SysStructModel entity = new SysStructModel()
            {
                ParentId = id,
                Enable = true,
                Sort = 0
            };
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Create(SysStructModel model)
        {
            model.Id = ResultHelper.NewId;
            model.CreateTime = ResultHelper.NowTime;
            if (ModelState.IsValid)
            {

                if (m_BLL.Create(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",Name" + model.Name, "成功", "创建", "SysStruct");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed));
                }
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",Name" + model.Name + "," + ErrorCol, "失败", "创建", "SysStruct");
                return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail + ErrorCol));
            }
            return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail));
        }
        #endregion

        #region 修改
        [SupportFilter]
        public ActionResult Edit(string id)
        {
            ViewBag.Perm = GetPermission();
            SysStructModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(SysStructModel model)
        {
            if (ModelState.IsValid)
            {

                if (m_BLL.Edit(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",Name" + model.Name, "成功", "修改", "SysStruct");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.EditSucceed));
                }
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",Name" + model.Name + "," + ErrorCol, "失败", "修改", "SysStruct");
                return Json(JsonHandler.CreateMessage(0, Suggestion.EditFail + ErrorCol));
            }
            return Json(JsonHandler.CreateMessage(0, Suggestion.EditFail));
        }
        #endregion

        #region 删除
        [HttpPost]
        [SupportFilter]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (m_BLL.Delete(ref errors, id))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id, "成功", "删除", "SysStruct");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed));
                }
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(GetUserId(), "Id" + id + "," + ErrorCol, "失败", "删除", "SysStruct");
                return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail + ErrorCol));
            }
            return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail));
        }
        #endregion
    }
}