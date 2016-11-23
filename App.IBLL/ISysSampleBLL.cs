using System.Collections.Generic;
using App.Common;
using App.Models.Sys;

namespace App.IBLL
{
    public interface ISysSampleBLL
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryStr">查询字符串</param>
        /// <returns>列表</returns>
        List<SysSampleModel> GetList(ref GridPager pager,string queryStr);

        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="entity">模型</param>
        /// <returns>是否成功</returns>
        bool Create(ref ValidationErrors errors,SysSampleModel entity);

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>是否成功</returns>
        bool Delete(ref ValidationErrors errors,string id);

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity">模型</param>
        /// <returns>是否成功</returns>
        bool Edit(ref ValidationErrors errors,SysSampleModel entity);

        /// <summary>
        /// 根据Id获得一个Model实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>Model实体</returns>
        SysSampleModel GetById(string id);

        /// <summary>
        /// 判断是否存在一个实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>是否存在</returns>
        bool IsExist(string id);
    }
}
