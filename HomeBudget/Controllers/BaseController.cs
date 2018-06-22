using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBudget.Models;

namespace HomeBudget.Controllers
{
    class BaseController
    {
        protected DAL.AppContext db = new DAL.AppContext();

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
