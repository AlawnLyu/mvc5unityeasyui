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
    
    public partial class SysStruct
    {
        public SysStruct()
        {
            this.SysStruct1 = new HashSet<SysStruct>();
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public int Sort { get; set; }
        public string Higher { get; set; }
        public bool Enable { get; set; }
        public string Remark { get; set; }
        public System.DateTime CreateTime { get; set; }
    
        public virtual ICollection<SysStruct> SysStruct1 { get; set; }
        public virtual SysStruct SysStruct2 { get; set; }
    }
}