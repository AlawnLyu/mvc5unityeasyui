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
    public class SysExceptionBLL : BaseBLL, ISysExceptionBLL
    {
        [Dependency]
        public ISysExceptionRepository exceptionRepository { get; set; }
        public List<SysExceptionModel> GetList(ref GridPager pager, string queryStr)
        {
            IQueryable<SysException> queryData = null;
            queryData = exceptionRepository.GetList(db);
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = queryData.Where(o => o.Message.Contains(queryStr));
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }

        private List<SysExceptionModel> CreateModelList(ref IQueryable<SysException> queryData)
        {
            List<SysExceptionModel> modelList = (from r in queryData
                                                 select new SysExceptionModel
                                           {
                                               Id = r.Id,
                                               HelpLink = r.HelpLink,
                                               Message = r.Message,
                                               Source = r.Source,
                                               StackTrace = r.StackTrace,
                                               TargetSite = r.TargetSite,
                                               Data = r.Data,
                                               CreateTime = r.CreateTime,

                                           }).ToList();

            return modelList;
        }

        public SysExceptionModel GetById(string id)
        {
            if (IsExist(id))
            {
                SysException entity = exceptionRepository.GetById(id);
                SysExceptionModel model = new SysExceptionModel();
                model.Id = entity.Id;
                model.HelpLink = entity.HelpLink;
                model.Message = entity.Message;
                model.Source = entity.Source;
                model.StackTrace = entity.StackTrace;
                model.TargetSite = entity.TargetSite;
                model.Data = entity.Data;
                model.CreateTime = entity.CreateTime;

                return model;
            }
            else
            {
                return new SysExceptionModel();
            }
        }

        public bool IsExist(string id)
        {
            return exceptionRepository.IsExist(id);
        }

        public bool Create(SysExceptionModel model)
        {
            try
            {
                if (exceptionRepository.IsExist(model.Id))
                {
                    return false;
                }
                SysException entity = new SysException
                {
                    Id = ResultHelper.NewId,
                    HelpLink = model.HelpLink,
                    Message = model.Message,
                    Source = model.Source,
                    StackTrace = model.StackTrace,
                    TargetSite = model.TargetSite,
                    Data = model.Data,
                    CreateTime = model.CreateTime
                };
                return exceptionRepository.Create(entity) == 1;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
