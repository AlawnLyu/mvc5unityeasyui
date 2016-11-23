﻿using System.Collections.Generic;
using App.Common;
using App.Models.Flow;

namespace App.Flow.IBLL
{
    public interface IFlow_FormAttrBLL
    {
        List<Flow_FormAttrModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, Flow_FormAttrModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, Flow_FormAttrModel model);
        Flow_FormAttrModel GetById(string id);
        bool IsExist(string id); 
    }
}