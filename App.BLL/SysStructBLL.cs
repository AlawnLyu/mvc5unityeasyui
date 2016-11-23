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
    public class SysStructBLL : BaseBLL, ISysStructBLL
    {
        [Dependency]
        public ISysStructRepository m_Rep { get; set; }

        public List<SysStructModel> GetList(string parentId)
        {
            IQueryable<SysStruct> queryData = m_Rep.GetList(db);
            queryData = queryData.Where(a => a.ParentId == parentId && a.Id != "0").OrderBy(o => o.Sort);
            return CreateModelList(ref queryData);
        }

        private List<SysStructModel> CreateModelList(ref IQueryable<SysStruct> queryData)
        {

            List<SysStructModel> modelList = (from r in queryData
                                              select new SysStructModel
                                              {
                                                  CreateTime = r.CreateTime,
                                                  Enable = r.Enable,
                                                  Higher = r.Higher,
                                                  Id = r.Id,
                                                  Name = r.Name,
                                                  ParentId = r.ParentId,
                                                  Remark = r.Remark,
                                                  Sort = r.Sort
                                              }).ToList();
            return modelList;
        }

        public bool Create(ref ValidationErrors errors, SysStructModel model)
        {
            try
            {
                SysStruct entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new SysStruct();
                entity.CreateTime = model.CreateTime;
                entity.Enable = model.Enable;
                entity.Higher = model.Higher;
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.ParentId = model.ParentId;
                entity.Remark = model.Remark;
                entity.Sort = model.Sort;
                if (m_Rep.Create(entity) == 1)
                {
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
                if (db.SysStruct.AsQueryable().Any(a => a.SysStruct2.Id == id))
                {
                    errors.Add("有下属关联，请先删除下属!");
                    return false;
                }
                if (m_Rep.Delete(id) == 1)
                {
                    //清楚unused depid
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

        public bool Edit(ref ValidationErrors errors, SysStructModel model)
        {
            try
            {
                SysStruct entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.CreateTime = model.CreateTime;
                entity.Enable = model.Enable;
                entity.Higher = model.Higher;
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.ParentId = model.ParentId;
                entity.Remark = model.Remark;
                entity.Sort = model.Sort;

                if (m_Rep.Edit(entity) == 1)
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

        public SysStructModel GetById(string id)
        {
            if (IsExist(id))
            {
                SysStruct entity = m_Rep.GetById(id);
                SysStructModel model = new SysStructModel();
                model.CreateTime = entity.CreateTime;
                model.Enable = entity.Enable;
                model.Higher = entity.Higher;
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.ParentId = entity.ParentId;
                model.Remark = entity.Remark;
                model.Sort = entity.Sort;
                return model;
            }
            return null;
        }

        public bool IsExists(string id)
        {
            if (db.SysStruct.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public bool IsExist(string id)
        {
            return m_Rep.IsExist(id);
        }
    }
}
