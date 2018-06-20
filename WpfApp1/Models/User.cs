using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class User : INotifyPropertyChanged
    {
        private string name;
        public event PropertyChangedEventHandler PropertyChanged;

        public int ID { get; set; }
        public string FirstName {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanges("FirstName");
            }
        }
        public string LastName { get; set; }

        protected void OnPropertyChanges(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        
    }
}
