//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace App.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Flow_FormContent
    {
        public Flow_FormContent()
        {
            this.Flow_FormContentStepCheck = new HashSet<Flow_FormContentStepCheck>();
        }
    
        public string Id { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        public string FormId { get; set; }
        public string FormLevel { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string AttrA { get; set; }
        public string AttrB { get; set; }
        public string AttrC { get; set; }
        public string AttrD { get; set; }
        public string AttrE { get; set; }
        public string AttrF { get; set; }
        public string AttrG { get; set; }
        public string AttrH { get; set; }
        public string AttrI { get; set; }
        public string AttrJ { get; set; }
        public string AttrK { get; set; }
        public string AttrL { get; set; }
        public string AttrM { get; set; }
        public string AttrN { get; set; }
        public string AttrO { get; set; }
        public string AttrP { get; set; }
        public string AttrQ { get; set; }
        public string AttrR { get; set; }
        public string AttrS { get; set; }
        public string AttrT { get; set; }
        public string AttrU { get; set; }
        public string AttrV { get; set; }
        public string AttrW { get; set; }
        public string AttrX { get; set; }
        public string AttrY { get; set; }
        public string AttrZ { get; set; }
        public string CustomMember { get; set; }
        public System.DateTime TimeOut { get; set; }
    
        public virtual Flow_Form Flow_Form { get; set; }
        public virtual SysUser SysUser { get; set; }
        public virtual ICollection<Flow_FormContentStepCheck> Flow_FormContentStepCheck { get; set; }
    }
}
