using System.Linq;
using App.Models;

namespace App.Flow.IDAL
{
    public interface IFlow_StepRuleRepository
    {
        IQueryable<Flow_StepRule> GetList(DBContainer db);
        int Create(Flow_StepRule entity);
        int Delete(string id);
        void Delete(DBContainer db, string[] deleteCollection);
        int Edit(Flow_StepRule entity);
        Flow_StepRule GetById(string id);
        bool IsExist(string id); 
    }
}