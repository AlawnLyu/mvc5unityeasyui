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
    
    public partial class Flow_Form
    {
        public Flow_Form()
        {
            this.Flow_FormContent = new HashSet<Flow_FormContent>();
            this.Flow_Step = new HashSet<Flow_Step>();
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public string UsingDep { get; set; }
        public string TypeId { get; set; }
        public bool State { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string HtmlForm { get; set; }
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
    
        public virtual Flow_Type Flow_Type { get; set; }
        public virtual ICollection<Flow_FormContent> Flow_FormContent { get; set; }
        public virtual ICollection<Flow_Step> Flow_Step { get; set; }
    }
}
