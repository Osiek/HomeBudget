using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Models
{
    class Item
    {


        public int ID { get; set; }
        public int EntryID { get; set; }
        public int? CategoryID { get; set; }
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
        public string Name { get; set; }

        public virtual Entry Entry { get; set; }
        public virtual Category Category { get; set; }
    }
}
