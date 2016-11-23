using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using App.Common;
using App.BLL.Core;
using App.MIS.IBLL;
using App.Models.MIS;
using App.MIS.IDAL;
using App.Models;
using Microsoft.Practices.Unity;

namespace App.MIS.BLL
{
    public class MIS_ArticleBLL : BaseBLL, IMIS_ArticleBLL
    {
        [Dependency]
        public IMIS_ArticleRepository m_Rep { get; set; }

        public List<MIS_ArticleModel> GetList(ref GridPager pager, string queryStr)
        {
            IQueryable<MIS_Article> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.Title.Contains(queryStr) || a.Creater.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }

        private List<MIS_ArticleModel> CreateModelList(ref IQueryable<MIS_Article> queryData)
        {
            List<MIS_ArticleModel> modelList = (from r in queryData
                                                select new MIS_ArticleModel
                                                {
                                                    BodyContent = r.BodyContent,
                                                    CategoryId = r.CategoryId,
                                                    ChannelId = r.ChannelId,
                                                    CheckDateTime = r.CheckDateTime ?? DateTime.Now,
                                                    Checker = r.Checker,
                                                    CheckFlag = r.CheckFlag,
                                                    Click = r.Click ?? 0,
                                                    Creater = r.Creater,
                                                    CreateTime = r.CreateTime ?? DateTime.Now,
                                                    Id = r.Id,
                                                    ImgUrl = r.ImgUrl,
                                                    Sort = r.Sort ?? 0,
                                                    Title = r.Title
                                                }).ToList();
            return modelList;
        }

        public bool Create(ref ValidationErrors errors, MIS_ArticleModel model)
        {
            try
            {
                MIS_Article entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new MIS_Article();
                entity.BodyContent = model.BodyContent;
                entity.CategoryId = model.CategoryId;
                entity.ChannelId = model.ChannelId;
                entity.CheckDateTime = model.CheckDateTime;
                entity.Checker = model.Checker;
                entity.CheckFlag = model.CheckFlag;
                entity.Click = model.Click;
                entity.Creater = model.Creater;
                entity.CreateTime = model.CreateTime;
                entity.Id = model.Id;
                entity.ImgUrl = model.ImgUrl;
                entity.Sort = model.Sort;
                entity.Title = model.Title;
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
                if (m_Rep.Delete(id) == 1)
                {
                    return true;
                }
                errors.Add(Suggestion.DeleteFail);
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

        public bool Delete(ref ValidationErrors errors, string[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                {
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        m_Rep.Delete(db, deleteCollection);
                        if (db.SaveChanges() == deleteCollection.Length)
                        {
                            transactionScope.Complete();
                            return true;
                        }
                        Transaction.Current.Rollback();
                        return false;
                    }
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

        public bool Edit(ref ValidationErrors errors, MIS_ArticleModel model)
        {
            try
            {
                MIS_Article entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.BodyContent = model.BodyContent;
                entity.CategoryId = model.CategoryId;
                entity.ChannelId = model.ChannelId;
                entity.CheckDateTime = model.CheckDateTime;
                entity.Checker = model.Checker;
                entity.CheckFlag = model.CheckFlag;
                entity.Click = model.Click;
                entity.Creater = model.Creater;
                entity.CreateTime = model.CreateTime;
                entity.Id = model.Id;
                entity.ImgUrl = model.ImgUrl;
                entity.Sort = model.Sort;
                entity.Title = model.Title;

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

        public MIS_ArticleModel GetById(string id)
        {
            if (IsExist(id))
            {
                MIS_Article entity = m_Rep.GetById(id);
                MIS_ArticleModel model = new MIS_ArticleModel
                {
                    BodyContent = entity.BodyContent,
                    CategoryId = entity.CategoryId,
                    ChannelId = entity.ChannelId,
                    CheckDateTime = entity.CheckDateTime ?? DateTime.Now,
                    Checker = entity.Checker,
                    CheckFlag = entity.CheckFlag,
                    Click = entity.Click ?? 0,
                    Creater = entity.Creater,
                    CreateTime = entity.CreateTime ?? DateTime.Now,
                    Id = entity.Id,
                    ImgUrl = entity.ImgUrl,
                    Sort = entity.Sort ?? 0,
                    Title = entity.Title
                };
                return model;
            }
            return null;
        }

        public bool IsExists(string id)
        {
            if (db.MIS_Article.SingleOrDefault(a => a.Id == id) != null)
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
