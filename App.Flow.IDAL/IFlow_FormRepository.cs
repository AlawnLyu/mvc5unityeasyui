using System.Linq;
using App.Models;

namespace App.Flow.IDAL
{
    public interface IFlow_FormRepository
    {
        IQueryable<Flow_Form> GetList(DBContainer db);
        int Create(Flow_Form entity);
        int Delete(string id);
        void Delete(DBContainer db, string[] deleteCollection);
        int Edit(Flow_Form entity);
        Flow_Form GetById(string id);
        bool IsExist(string id);
    }
}