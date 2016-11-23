using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;

namespace App.IDAL
{
    public interface ISysExceptionRepository
    {
        int Create(SysException entity);

        IQueryable<SysException> GetList(DBContainer db);

        SysException GetById(string id);

        bool IsExist(string id);
    }
}
