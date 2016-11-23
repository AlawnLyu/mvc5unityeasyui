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
    
    public partial class SysModule
    {
        public SysModule()
        {
            this.SysModule1 = new HashSet<SysModule>();
            this.SysModuleOperate = new HashSet<SysModuleOperate>();
            this.SysRight = new HashSet<SysRight>();
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public string ParentId { get; set; }
        public string Url { get; set; }
        public string Iconic { get; set; }
        public Nullable<int> Sort { get; set; }
        public string Remark { get; set; }
        public string CreatePerson { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public bool IsLast { get; set; }
        public byte[] Version { get; set; }
        public Nullable<bool> Enable { get; set; }
    
        public virtual ICollection<SysModule> SysModule1 { get; set; }
        public virtual SysModule SysModule2 { get; set; }
        public virtual ICollection<SysModuleOperate> SysModuleOperate { get; set; }
        public virtual ICollection<SysRight> SysRight { get; set; }
    }
}
