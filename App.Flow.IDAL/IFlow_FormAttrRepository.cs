using System.Linq;
using App.Models;

namespace App.Flow.IDAL
{
    public interface IFlow_FormAttrRepository
    {
        IQueryable<Flow_FormAttr> GetList(DBContainer db);
        int Create(Flow_FormAttr entity);
        int Delete(string id);
        void Delete(DBContainer db, string[] deleteCollection);
        int Edit(Flow_FormAttr entity);
        Flow_FormAttr GetById(string id);
        bool IsExist(string id); 
    }
}