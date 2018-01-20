using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Models
{
    class ItemCategory
    {
        public int ID { get; set; }
        public int EntryID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        [Column(Type)]
        public decimal Price { get; set; }
    }
}
