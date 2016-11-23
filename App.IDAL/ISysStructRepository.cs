using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;

namespace App.IDAL
{
    public interface ISysStructRepository
    {
        IQueryable<SysStruct> GetList(DBContainer db);
        int Create(SysStruct entity);
        int Delete(string id);
        void Delete(DBContainer db, string[] deleteCollection);
        int Edit(SysStruct entity);
        SysStruct GetById(string id);
        bool IsExist(string id);
    }
}
