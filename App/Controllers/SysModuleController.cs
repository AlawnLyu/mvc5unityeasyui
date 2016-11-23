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
    public class SysModuleController : BaseController
    {
        [Dependency]
        public ISysModuleBLL m_BLL { get; set; }

        [Dependency]
        public ISysModuleOperateBLL operateBLL { get; set; }

        private ValidationErrors errors = new ValidationErrors();

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
            List<SysModuleModel> list = m_BLL.GetList(id);
            var json = from r in list
                       select new SysModuleModel()
                       {
                           Id = r.Id,
                           Name = r.Name,
                           EnglishName = r.EnglishName,
                           ParentId = r.ParentId,
                           Url = r.Url,
                           Iconic = r.Iconic,
                           Sort = r.Sort,
                           Remark = r.Remark,
                           Enable = r.Enable,
                           CreatePerson = r.CreatePerson,
                           CreateTime = r.CreateTime,
                           IsLast = r.IsLast,
                           state = (m_BLL.GetList(r.Id).Count > 0) ? "closed" : "open"
                       };
            return Json(json);
        }

        [HttpPost]
        [SupportFilter(ActionName = "Index")]
        public JsonResult GetOptListByModule(GridPager pager, string mid)
        {
            pager.rows = 1000;
            pager.page = 1;
            List<SysModuleOperateModel> list = operateBLL.GetList(ref pager, mid);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new SysModuleOperateModel()
                        {
                            Id = r.Id,
                            Name = r.Name,
                            KeyCode = r.KeyCode,
                            ModuleId = r.ModuleId,
                            IsValid = r.IsValid,
                            Sort = r.Sort
                        }).ToArray()
            };
            return Json(json);
        }

        #region 创建模块
        [SupportFilter]
        public ActionResult Create(string id)
        {
            ViewBag.Perm = GetPermission();
            SysModuleModel entity = new SysModuleModel()
            {
                ParentId = id,
                Enable = true,
                Sort = 0
            };
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public ActionResult Create(SysModuleModel model)
        {
            model.Id = ResultHelper.NewId;
            model.CreateTime = ResultHelper.NowTime;
            model.CreatePerson = GetUserId();
            if (ModelState.IsValid)
            {
                if (m_BLL.Create(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",Name" + model.Name, "成功", "创建", "SysModule");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed));
                }
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",Name" + model.Name + "," + ErrorCol, "失败", "创建", "SysModule");
                return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail + ErrorCol));
            }
            return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail));
        }
        #endregion

        #region 创建操作码
        [SupportFilter(ActionName = "Create")]
        public ActionResult CreateOpt(string moduleId)
        {
            ViewBag.Perm = GetPermission();
            SysModuleOperateModel sysModuleOptModel = new SysModuleOperateModel();
            sysModuleOptModel.ModuleId = moduleId;
            sysModuleOptModel.IsValid = true;
            return View(sysModuleOptModel);
        }

        [HttpPost]
        [SupportFilter(ActionName = "Create")]
        public ActionResult CreateOpt(SysModuleOperateModel model)
        {
            if (ModelState.IsValid)
            {
                SysModuleOperateModel entity = operateBLL.GetById(model.Id);
                if (entity != null)
                    return Json(JsonHandler.CreateMessage(0, Suggestion.PrimaryRepeat), JsonRequestBehavior.AllowGet);

                entity = new SysModuleOperateModel();
                entity.Id = model.ModuleId + model.KeyCode;
                entity.Name = model.Name;
                entity.KeyCode = model.KeyCode;
                entity.ModuleId = model.ModuleId;
                entity.IsValid = model.IsValid;
                entity.Sort = model.Sort;
                if (operateBLL.Create(ref errors, entity))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",Name:" + model.Name, "成功", "创建", "模块设置");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed), JsonRequestBehavior.AllowGet);
                }
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",Name:" + model.Name + "," + ErrorCol, "失败", "创建", "模块设置");
                return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail + ErrorCol), JsonRequestBehavior.AllowGet);
            }
            return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 修改模块
        [SupportFilter]
        public ActionResult Edit(string id)
        {
            ViewBag.Perm = GetPermission();
            SysModuleModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public ActionResult Edit(SysModuleModel model)
        {
            if (ModelState.IsValid)
            {
                if (m_BLL.Edit(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",Name" + model.Name, "成功", "修改", "系统菜单");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.EditSucceed));
                }
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",Name" + model.Name + "," + ErrorCol, "失败", "修改", "系统菜单");
                return Json(JsonHandler.CreateMessage(0, Suggestion.EditFail + ErrorCol));
            }
            return Json(JsonHandler.CreateMessage(0, Suggestion.EditFail));
        }
        #endregion

        #region 删除
        [HttpPost]
        [SupportFilter]
        public ActionResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (m_BLL.Delete(ref errors, id))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Ids:" + id, "成功", "删除", "模块设置");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed), JsonRequestBehavior.AllowGet);
                }
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(GetUserId(), "Id:" + id + "," + ErrorCol, "失败", "删除", "模块设置");
                return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail + ErrorCol), JsonRequestBehavior.AllowGet);
            }
            return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [SupportFilter(ActionName = "Delete")]
        public ActionResult DeleteOpt(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (operateBLL.Delete(ref errors, id))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Ids:" + id, "成功", "删除", "模块设置KeyCode");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed), JsonRequestBehavior.AllowGet);
                }
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(GetUserId(), "Id:" + id + "," + ErrorCol, "失败", "删除", "模块设置KeyCode");
                return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail + ErrorCol), JsonRequestBehavior.AllowGet);
            }
            return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}