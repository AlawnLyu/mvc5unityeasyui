using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Sys
{
    public class SysStructModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "名称")]
        public string Name { get; set; }

        [Display(Name = "上级ID")]
        public string ParentId { get; set; }

        [Display(Name = "排序")]
        public int Sort { get; set; }

        [Display(Name = "Higher")]
        public string Higher { get; set; }

        [Display(Name = "是否启用")]
        public bool Enable { get; set; }

        [Display(Name = "说明")]
        public string Remark { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        public string state { get; set; }//treegrid
    }
}
