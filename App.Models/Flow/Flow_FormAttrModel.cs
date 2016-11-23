using System;
using System.ComponentModel.DataAnnotations;

namespace App.Models.Flow
{
    public class Flow_FormAttrModel
    {
        [Display(Name = "ID")]
        public string Id { get; set; }

        [Display(Name = "字段标题")]
        public string Title { get; set; }

        [Display(Name = "字段英文名称")]
        public string Name { get; set; }

        [Display(Name = "文本,日期,数字,多行文本")]
        public string AttrType { get; set; }

        [Display(Name = "校验脚本")]
        public string CheckJS { get; set; }

        [Display(Name = "所属类别")]
        public string TypeId { get; set; }

        [Display(Name = "CreateTime")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "下拉框的值")]
        public string OptionList { get; set; }

        [Display(Name = "是否必填")]
        public bool IsValid { get; set; }
    }
}