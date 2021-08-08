using CVC_Poc.Models.Constant;
using CVC_Poc.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVC_Poc.Models.ViewModels
{
    public class ScreenVm
    {
        public ScreenVm()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public TemplateTypes TemplateTypes { get; set; }
        public string TemplateName { get; set; }
        public string CustomerName { get; set; }
        public List<ObjectPlacement> ObjectPlacements { get; set; }
        public List<SelectListItem> ObjectList { get; } = new List<SelectListItem>();
        public int UserId { get; set; }

        public List<SelectListItem> CustomersList { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "2", Text = "Vidya" },
            new SelectListItem { Value = "3", Text = "Raj" }
        };
        public List<SelectListItem> Templates { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Template1" },
            new SelectListItem { Value = "2", Text = "Template2" }
        };

        public int Element1 { get; set; }
        public int Element2 { get; set; }
    }

    public class ScreenMenu
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public class ScreenLoad
    {
        public ScreenLoad()
        {
            ElementFormTypes = new List<ElementFieldType>();
        }
        public string ScreenName { get; set; }
        public string TemplateName { get; set; }
        
        public ElementListTypeVm ElementListType { get; set; }

        public List<ElementFieldType> ElementFormTypes { get; set; }
    }

}
