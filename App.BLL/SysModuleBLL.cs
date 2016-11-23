using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.BLL.Core;
using App.Common;
using App.IBLL;
using App.IDAL;
using App.Models;
using App.Models.Sys;
using Microsoft.Practices.Unity;

namespace App.BLL
{
    public class SysModuleBLL : BaseBLL, ISysModuleBLL
    {
        [Dependency]
        public ISysModuleRepository m_rep { get; set; }

        public List<SysModuleModel> GetList(string parentId)
        {
            IQueryable<SysModule> queryData = m_rep.GetList(db);
            queryData = queryData.Where(a => a.ParentId == parentId && a.Id != "0").OrderBy(o => o.Sort);
            return CreateModelList(ref queryData);
        }

        private List<SysModuleModel> CreateModelList(ref IQueryable<SysModule> queryData)
        {
            List<SysModuleModel> modelList = (from r in queryData
                                              select new SysModuleModel
                                              {
                                                  Id = r.Id,
                                                  Name = r.Name,
                                                  EnglishName = r.EnglishName,
                                                  ParentId = r.ParentId,
                                                  Url = r.Url,
                                                  Iconic = r.Iconic,
                                                  Sort = r.Sort,
                                                  Remark = r.Remark,
                                                  Enable = (bool) r.Enable,
                                                  CreatePerson = r.CreatePerson,
                                                  CreateTime = r.CreateTime,
                                                  IsLast = r.IsLast
                                              }).ToList();
            return modelList;
        }

        public List<SysModule> GetModuleBySystem(string parentId)
        {
            return m_rep.GetModuleBySystem(db, parentId).ToList();
        }

        public bool Create(ref ValidationErrors errors, SysModuleModel model)
        {
            try
            {
                SysModule entity = m_rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new SysModule
                {
                    Id = model.Id,
                    Name = model.Name,
                    EnglishName = model.EnglishName,
                    ParentId = model.ParentId,
                    Url = model.Url,
                    Iconic = model.Iconic,
                    Sort = model.Sort,
                    Remark = model.Remark,
                    Enable = model.Enable,
                    CreatePerson = model.CreatePerson,
                    CreateTime = model.CreateTime,
                    IsLast = model.IsLast
                };
                if (m_rep.Create(entity) == 1)
                {
                    //分配给角色
                    db.P_Sys_InsertSysRight();
                    return true;
                }
                errors.Add(Suggestion.InsertFail);
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

        public bool Delete(ref ValidationErrors errors, string id)
        {
            try
            {
                //检查是否有下级
                if (db.SysModule.AsQueryable().Any(a => a.SysModule2.Id == id))
                {
                    errors.Add("有下属关联，请先删除下属!");
                    return false;
                }
                m_rep.Delete(db, id);
                if (db.SaveChanges() > 0)
                {
                    db.P_Sys_ClearUnusedRightOperate();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

        public bool Edit(ref ValidationErrors errors, SysModuleModel model)
        {
            try
            {
                SysModule entity = m_rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.Name = model.Name;
                entity.EnglishName = model.EnglishName;
                entity.ParentId = model.ParentId;
                entity.Url = model.Url;
                entity.Iconic = model.Iconic;
                entity.Sort = model.Sort;
                entity.Remark = model.Remark;
                entity.Enable = model.Enable;
                entity.IsLast = model.IsLast;
                if (m_rep.Edit(entity) == 1)
                {
                    return true;
                }
                errors.Add(Suggestion.EditFail);
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

        public SysModuleModel GetById(string id)
        {
            if (IsExist(id))
            {
                SysModule entity = m_rep.GetById(id);
                SysModuleModel model = new SysModuleModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    EnglishName = entity.EnglishName,
                    ParentId = entity.ParentId,
                    Url = entity.Url,
                    Iconic = entity.Iconic,
                    Sort = entity.Sort,
                    Remark = entity.Remark,
                    Enable = (bool) entity.Enable,
                    CreatePerson = entity.CreatePerson,
                    CreateTime = entity.CreateTime,
                    IsLast = entity.IsLast
                };
                return model;
            }
            return null;
        }

        public bool IsExist(string id)
        {
            return m_rep.IsExist(id);
        }
    }
}
