using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayImage { get; set; }
        public bool? IsActive { get; set; }
        public int? Order { get; set; }
        public string StoreName { get; set; }
        public string Pin { get; set; }
        public string Pin2 { get; set; }
    }
}
