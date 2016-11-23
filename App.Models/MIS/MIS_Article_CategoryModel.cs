using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.MIS
{
    public class MIS_Article_CategoryModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "ChannelId")]
        public int ChannelId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "ParentId")]
        public string ParentId { get; set; }

        [Display(Name = "Sort")]
        public int Sort { get; set; }

        [Display(Name = "ImgUrl")]
        public string ImgUrl { get; set; }

        [Display(Name = "BodyContent")]
        public string BodyContent { get; set; }

        [Display(Name = "CreateTime")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "Enable")]
        public bool Enable { get; set; }
    }
}
