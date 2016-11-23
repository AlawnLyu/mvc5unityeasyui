using System;
using System.Collections.Generic;
using System.Linq;
using App.BLL.Core;
using App.Common;
using App.IBLL;
using App.IDAL;
using App.Models;
using App.Models.Sys;
using Microsoft.Practices.Unity;

namespace App.BLL
{
    public class SysSampleBLL :BaseBLL, ISysSampleBLL
    {
        [Dependency]
        public ISysSampleRepository Rep { get; set; }

        public List<SysSampleModel> GetList(ref GridPager pager, string queryStr)
        {
            IQueryable<SysSample> queryData = null;
            queryData = Rep.GetList(db, queryStr);
            return CreateModelList(ref pager, ref queryData);
        }

        private List<SysSampleModel> CreateModelList(ref GridPager pager, ref IQueryable<SysSample> queryData)
        {
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging<SysSample>(queryData, pager.sort, pager.order, pager.page, pager.rows);
            List<SysSampleModel> modelList = (from r in queryData
                                              select new SysSampleModel
                                              {
                                                  Id = r.Id,
                                                  Name = r.Name,
                                                  Age = r.Age,
                                                  Bir = r.Bir,
                                                  Photo = r.Photo,
                                                  Note = r.Note,
                                                  CreateTime = r.CreateTime,

                                              }).ToList();

            return modelList;
        }

        public bool Create(ref ValidationErrors errors, SysSampleModel model)
        {
            try
            {
                SysSample entity = Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add("主键重复");
                    return false;
                }
                entity = new SysSample();
                entity.Id = ResultHelper.NewId;
                entity.Name = model.Name;
                entity.Age = model.Age;
                entity.Bir = model.Bir;
                entity.Photo = model.Photo;
                entity.Note = model.Note;
                entity.CreateTime = DateTime.Now;

                if (Rep.Create(entity) == 1)
                {
                    return true;
                }
                errors.Add("插入失败");
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
                if (Rep.Delete(id) == 1)
                {
                    return true;
                }
                errors.Add("删除失败");
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

        public bool Edit(ref ValidationErrors errors, SysSampleModel model)
        {
            try
            {
                SysSample entity = Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add("数据不存在");
                    return false;
                }
                entity.Name = model.Name;
                entity.Age = model.Age;
                entity.Bir = model.Bir;
                entity.Photo = model.Photo;
                entity.Note = model.Note;

                if (Rep.Edit(entity) == 1)
                {
                    return true;
                }
                errors.Add("修改失败");
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

        public SysSampleModel GetById(string id)
        {
            if (IsExist(id))
            {
                SysSample entity = Rep.GetById(id);
                SysSampleModel model = new SysSampleModel();
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.Age = entity.Age;
                model.Bir = entity.Bir;
                model.Photo = entity.Photo;
                model.Note = entity.Note;
                model.CreateTime = entity.CreateTime;

                return model;
            }
            return new SysSampleModel();
        }

        public bool IsExist(string id)
        {
            return Rep.IsExist(id);
        }
    }
}
