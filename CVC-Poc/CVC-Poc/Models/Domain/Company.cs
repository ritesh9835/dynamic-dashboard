using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CVC_Poc.Models.Domain
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string HeadOffice { get; set; }
        public string Founder { get; set; }
        public int FoundingYear { get; set; }
        public int HeadCount { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
    }
}
