using System.Linq;
using App.Models;

namespace App.Flow.IDAL
{
    public interface IFlow_StepRepository
    {
        IQueryable<Flow_Step> GetList(DBContainer db);
        int Create(Flow_Step entity);
        int Delete(string id);
        void Delete(DBContainer db, string[] deleteCollection);
        int Edit(Flow_Step entity);
        Flow_Step GetById(string id);
        bool IsExist(string id); 
    }
}