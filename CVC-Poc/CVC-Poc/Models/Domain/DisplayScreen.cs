using CVC_Poc.Models.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CVC_Poc.Models.Domain
{
    public class DisplayScreen
    {
        [Key]
        public int ScreenId { get; set; }
        public int UserId { get; set; }
        public int DeveloperId { get; set; }
        public string Name { get; set; }
        public TemplateTypes Template { get; set; }
        public List<ObjectPlacement> ObjectPlacements { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }

    public class ObjectPlacement
    {
        public int Objectid { get; set; }
        public int PlacedAt { get; set; }
    }
}
