using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Common;
using App.Models.Sys;

namespace App.IBLL
{
    public interface ISysStructBLL
    {
        List<SysStructModel> GetList(string parentId);
        bool Create(ref ValidationErrors errors, SysStructModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Edit(ref ValidationErrors errors, SysStructModel model);
        SysStructModel GetById(string id);
        bool IsExist(string id);
    }
}
