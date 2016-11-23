using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Common;
using App.IBLL;
using App.IDAL;
using App.Models;
using App.Models.Sys;
using Microsoft.Practices.Unity;

namespace App.BLL
{
    public class SysLogBLL : BaseBLL, ISysLogBLL
    {
        [Dependency]
        public ISysLogRepository logRepository { get; set; }

        public List<SysLogModel> GetList(ref GridPager pager, string queryStr)
        {
            IQueryable<SysLog> queryData = null;
            queryData = logRepository.GetList(db);
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = queryData.Where(s => s.Message.Contains(queryStr) || s.Module.Contains(queryStr));
            }
            return CreateModelList(ref pager, ref queryData);
        }

        private List<SysLogModel> CreateModelList(ref GridPager pager, ref IQueryable<SysLog> queryData)
        {
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            List<SysLogModel> modelList = (from r in queryData
                                           select new SysLogModel
                                              {
                                                  Id = r.Id,
                                                  Operator = r.Operator,
                                                  Message = r.Message,
                                                  Result = r.Result,
                                                  Type = r.Type,
                                                  Module = r.Module,
                                                  CreateTime = r.CreateTime,

                                              }).ToList();

            return modelList;
        }

        public SysLogModel GetById(string id)
        {
            if (IsExist(id))
            {
                SysLog entity = logRepository.GetById(id);
                SysLogModel model = new SysLogModel();
                model.Id = entity.Id;
                model.Operator = entity.Operator;
                model.Message = entity.Message;
                model.Result = entity.Result;
                model.Type = entity.Type;
                model.Module = entity.Module;
                model.CreateTime = entity.CreateTime;

                return model;
            }
            else
            {
                return new SysLogModel();
            }
        }

        public bool IsExist(string id)
        {
            return logRepository.IsExist(id);
        }

        public bool Create(SysLogModel model)
        {
            try
            {
                if (logRepository.IsExist(model.Id))
                {
                    return false;
                }
                SysLog entity = new SysLog();
                entity.Id = ResultHelper.NewId;
                entity.Operator = model.Operator;
                entity.Message = model.Message;
                entity.Result = model.Result;
                entity.Type = model.Type;
                entity.Module = model.Module;
                entity.CreateTime = ResultHelper.NowTime;

                return logRepository.Create(entity) == 1;
            }
            catch (Exception)
            {
                //ExceptionHander.WriteException(ex);
                return false;
            }
        }
    }
}
