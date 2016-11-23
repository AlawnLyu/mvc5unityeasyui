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
    public class SysModuleOperateBLL : BaseBLL, ISysModuleOperateBLL
    {
        [Dependency]
        public ISysModuleOperateRepository m_rep { get; set; }

        public List<SysModuleOperateModel> GetList(ref GridPager pager, string mid)
        {
            IQueryable<SysModuleOperate> queryData = m_rep.GetList(db).Where(a => a.ModuleId == mid);
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }

        private List<SysModuleOperateModel> CreateModelList(ref IQueryable<SysModuleOperate> queryData)
        {
            List<SysModuleOperateModel> modelList = (from r in queryData
                                                     select new SysModuleOperateModel
                                                     {
                                                         Id = r.Id,
                                                         Name = r.Name,
                                                         KeyCode = r.KeyCode,
                                                         ModuleId = r.ModuleId,
                                                         IsValid = r.IsValid,
                                                         Sort = r.Sort
                                                     }).ToList();
            return modelList;
        }

        public bool Create(ref ValidationErrors errors, SysModuleOperateModel model)
        {
            try
            {
                SysModuleOperate entity = m_rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new SysModuleOperate
                {
                    Id = model.Id,
                    Name = model.Name,
                    KeyCode = model.KeyCode,
                    ModuleId = model.ModuleId,
                    IsValid = model.IsValid,
                    Sort = model.Sort
                };
                if (m_rep.Create(entity) == 1)
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
                return m_rep.Delete(id) == 1;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

        public SysModuleOperateModel GetById(string id)
        {
            if (IsExist(id))
            {
                SysModuleOperate entity = m_rep.GetById(id);
                SysModuleOperateModel model = new SysModuleOperateModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    KeyCode = entity.KeyCode,
                    ModuleId = entity.ModuleId,
                    IsValid = entity.IsValid,
                    Sort = entity.Sort
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
