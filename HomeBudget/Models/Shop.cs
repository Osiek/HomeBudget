using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Models
{
    public class Shop
    {

        public Shop()
        {
            this.Entries = new ObservableCollection<Entry>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ObservableCollection<Entry> Entries { get; set; }
    }
}
