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
        public int ItemID { get; set; }
        public int CategoryID { get; set; }

        public virtual Item Item { get; set; }
        public virtual Category Category { get; set; }

    }
}
