using CVC_Poc.Models.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CVC_Poc.Models.Domain
{
    public class DisplayObject
    {
        [Key]
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int DeveloperId { get; set; }
        //Json of company table fields
        public List<string> Fields { get; set; }
        public DisplayType Type { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

     
    }

}
