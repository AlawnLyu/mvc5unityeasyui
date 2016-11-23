using System.Collections.Generic;
using App.Common;
using App.Models.Flow;

namespace App.Flow.IBLL
{
    public interface IFlow_StepRuleBLL
    {
        List<Flow_StepRuleModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, Flow_StepRuleModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, Flow_StepRuleModel model);
        Flow_StepRuleModel GetById(string id);
        bool IsExist(string id); 
    }
}