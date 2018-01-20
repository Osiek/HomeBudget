using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Models
{
    class Entry
    {
        public int ID { get; set; }
        public int ShopID { get; set; }
        [Column(TypeName="Date")]
        public DateTime Date { get; set; } 
        [Column(TypeName ="Money")]
        public decimal Ammount { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public virtual Shop Shop { get; set; }

    }
}
