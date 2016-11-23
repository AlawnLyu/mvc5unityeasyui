using System.ComponentModel.DataAnnotations;

namespace App.Models.Flow
{
    public class Flow_StepModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "步骤名称")]
        public string Name { get; set; }

        [Display(Name = "步骤说明")]
        public string Remark { get; set; }

        [Display(Name = "排序")]
        public int Sort { get; set; }

        [Display(Name = "所属表单")]
        public string FormId { get; set; }

        [Display(Name = "流转规则")]
        public string FlowRule { get; set; }

        [Display(Name = "该流程的 发起人/创建者 是否可以 自行选择 该步骤的审批者")]
        public bool IsCustom { get; set; }

        [Display(Name = "当规则或者角色被选择为多人时候，是否启用多人审核才通过")]
        public bool IsAllCheck { get; set; }

        [Display(Name = "执行者与规则对应")]
        public string Execution { get; set; }

        [Display(Name = "是否可以强制完成整个流程")]
        public bool CompulsoryOver { get; set; }

        [Display(Name = "审核者是否可以编辑发起者的附件")]
        public bool IsEditAttr { get; set; }
    }
}