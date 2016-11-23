using System.Collections.Generic;
using App.Common;
using App.Models.Flow;

namespace App.Flow.IBLL
{
    public interface IFlow_StepBLL
    {
        List<Flow_StepModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, Flow_StepModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, Flow_StepModel model);
        Flow_StepModel GetById(string id);
        bool IsExist(string id);
    }
}