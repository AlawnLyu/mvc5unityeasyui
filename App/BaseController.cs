using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Common;
using App.Models.Sys;

namespace App
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 获取当前用户Id
        /// </summary>
        /// <returns></returns>
        public string GetUserId()
        {
            if (Session["Account"] != null)
            {
                AccountModel info = Session["Account"] as AccountModel;
                return info.Id;
            }
            return "";
        }

        /// <summary>
        /// 获取当前用户Name
        /// </summary>
        /// <returns></returns>
        public string GetUserTrueName()
        {
            if (Session["Account"] != null)
            {
                AccountModel info = Session["Account"] as AccountModel;
                return info.TrueName;
            }
            return "";
        }

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        public AccountModel GetAccount()
        {
            if (Session["Account"] != null)
            {
                return Session["Account"] as AccountModel;
            }
            return null;
        }

        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new ToJsonResult
            {
                Data = data,
                ContentEncoding = contentEncoding,
                ContentType = contentType,
                JsonRequestBehavior = behavior,
                FormateStr = "yyyy-MM-dd HH:mm:ss"
            };
        }

        protected JsonResult MyJson(object data, JsonRequestBehavior behavior, string format)
        {
            return new ToJsonResult
            {
                Data = data,
                JsonRequestBehavior = behavior,
                FormateStr = format
            };
        }

        protected JsonResult MyJson(object data, string format)
        {
            return new ToJsonResult
            {
                Data = data,
                FormateStr = format
            };
        }

        protected JsonResult MyJson(object data)
        {
            return new ToJsonResult
            {
                Data = data,
                FormateStr = "yyyy-MM-dd HH:mm:ss"
            };
        }

        /// <summary>
        /// 检查sql语句合法性
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool ValidateSQL(string sql, ref string msg)
        {
            if (sql.ToLower().IndexOf("delete") > 0)
            {
                msg = "查询参数中含有非法语句DELETE";
                return false;
            }
            if (sql.ToLower().IndexOf("update") > 0)
            {
                msg = "查询参数中含有非法语句UPDATE";
                return false;
            }
            if (sql.ToLower().IndexOf("insert") > 0)
            {
                msg = "查询参数中含有非法语句INSERT";
                return false;
            }
            return true;
        }

        public List<permModel> GetPermission()
        {
            string filePath = HttpContext.Request.FilePath;
            List<permModel> perm = (List<permModel>)Session[filePath];
            return perm;
        }
    }
}