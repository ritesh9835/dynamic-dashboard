using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVC_Poc.Models.ViewModels
{
    public class ElementListTypeVm
    {
        public ElementListTypeVm()
        {
            Cells = new List<Cells>();
            Headers = new List<string>();
        }
        public int ColumnCount { get; set; }
        public int RowCount { get; set; }
        public List<string> Headers { get; set; }
        public List<Cells> Cells { get; set; }
    }

    public class Cells
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public string Text { get; set; }
    }

    public class ElementFieldType
    {
        public string FieldName { get; set; }
        public string FieldType { get; set; }
    }
}
