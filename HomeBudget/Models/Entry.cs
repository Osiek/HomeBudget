using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Models
{
    class Entry
    {

        public Entry()
        {
            this.Items = new ObservableCollection<Item>();
        }

        public int ID { get; set; }
        public int ShopID { get; set; }
        [Column(TypeName="Date")]
        public DateTime Date { get; set; } 
        [Column(TypeName ="Money")]
        public decimal Price { get; set; }
        public string Description { get; set; }

        public virtual ObservableCollection<Item> Items { get; set; }
        public virtual Shop Shop { get; set; }

    }
}
