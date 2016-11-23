using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Flow
{
    public class Flow_FormModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "名称")]
        public string Name { get; set; }

        [Display(Name = "说明")]
        public string Remark { get; set; }

        [Display(Name = "UsingDep")]
        public string UsingDep { get; set; }

        [Display(Name = "TypeId")]
        public string TypeId { get; set; }

        [Display(Name = "是否完成流程")]
        public bool State { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "HtmlForm")]
        public string HtmlForm { get; set; }

        [Display(Name = "AttrA")]
        public string AttrA { get; set; }

        [Display(Name = "AttrB")]
        public string AttrB { get; set; }

        [Display(Name = "AttrC")]
        public string AttrC { get; set; }

        [Display(Name = "AttrD")]
        public string AttrD { get; set; }

        [Display(Name = "AttrE")]
        public string AttrE { get; set; }

        [Display(Name = "AttrF")]
        public string AttrF { get; set; }

        [Display(Name = "AttrG")]
        public string AttrG { get; set; }

        [Display(Name = "AttrH")]
        public string AttrH { get; set; }

        [Display(Name = "AttrI")]
        public string AttrI { get; set; }

        [Display(Name = "AttrJ")]
        public string AttrJ { get; set; }

        [Display(Name = "AttrK")]
        public string AttrK { get; set; }

        [Display(Name = "AttrL")]
        public string AttrL { get; set; }

        [Display(Name = "AttrM")]
        public string AttrM { get; set; }

        [Display(Name = "AttrN")]
        public string AttrN { get; set; }

        [Display(Name = "AttrO")]
        public string AttrO { get; set; }

        [Display(Name = "AttrP")]
        public string AttrP { get; set; }

        [Display(Name = "AttrQ")]
        public string AttrQ { get; set; }

        [Display(Name = "AttrR")]
        public string AttrR { get; set; }

        [Display(Name = "AttrS")]
        public string AttrS { get; set; }

        [Display(Name = "AttrT")]
        public string AttrT { get; set; }

        [Display(Name = "AttrU")]
        public string AttrU { get; set; }

        [Display(Name = "AttrV")]
        public string AttrV { get; set; }

        [Display(Name = "AttrW")]
        public string AttrW { get; set; }

        [Display(Name = "AttrX")]
        public string AttrX { get; set; }

        [Display(Name = "AttrY")]
        public string AttrY { get; set; }

        [Display(Name = "AttrZ")]
        public string AttrZ { get; set; }
    }
}
