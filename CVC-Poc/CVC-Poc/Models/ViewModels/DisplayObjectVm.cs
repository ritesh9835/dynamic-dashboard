using CVC_Poc.Models.Constant;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CVC_Poc.Models.ViewModels
{

    public class DisplayObjectVm
    {
        public DisplayObjectVm()
        {
            FieldList = new List<SelectListItem>();
        }
        public int ObjectId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public List<string> Fields { get; set; }
        public DisplayType Type { get; set; }
        public string TypeVal { get; set; }
        public string TypeName { get; set; }

        public List<SelectListItem> Types { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "List" },
            new SelectListItem { Value = "2", Text = "Form" }
        };

        public List<SelectListItem> CustomersList { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "2", Text = "Vidya" },
            new SelectListItem { Value = "3", Text = "Raj" }
        };

        public List<SelectListItem> FieldList { get; set; }
        



    }
}
