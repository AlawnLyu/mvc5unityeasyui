using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.IBLL;
using App.IDAL;
using App.Models;
using App.Models.Sys;
using Microsoft.Practices.Unity;

namespace App.BLL
{
    public class HomeBLL : BaseBLL, IHomeBLL
    {
        [Dependency]
        public IHomeRepository HomeRepository { get; set; }

        public List<SysModule> GetMenuByPersonId(string personId, string moduleId)
        {
            return HomeRepository.GetMenuByPersonId(db, personId, moduleId);
        }
    }
}
