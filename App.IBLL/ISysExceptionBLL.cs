using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Common;
using App.Models.Sys;

namespace App.IBLL
{
    public interface ISysExceptionBLL
    {
        List<SysExceptionModel> GetList(ref GridPager pager, string queryStr);

        SysExceptionModel GetById(string id);

        bool IsExist(string id);

        bool Create(SysExceptionModel model);
    }
}
