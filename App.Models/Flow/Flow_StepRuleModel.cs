using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Flow
{
    public class Flow_StepRuleModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "StepId")]
        public string StepId { get; set; }

        [Display(Name = "AttrId")]
        public string AttrId { get; set; }

        [Display(Name = "Operator")]
        public string Operator { get; set; }

        [Display(Name = "Result")]
        public string Result { get; set; }

        [Display(Name = "NextStep")]
        public string NextStep { get; set; }

    }
}
