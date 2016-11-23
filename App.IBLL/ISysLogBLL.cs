using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Common;
using App.Models;
using App.Models.Sys;

namespace App.IBLL
{
    public interface ISysLogBLL
    {
        List<SysLogModel> GetList(ref GridPager pager, string queryStr);

        SysLogModel GetById(string id);

        bool IsExist(string id);

        bool Create(SysLogModel model);
    }
}
