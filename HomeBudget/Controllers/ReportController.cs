using HomeBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Controllers
{
    class ReportController : BaseController
    {
        public Dictionary<Shop, double> GetShopSummaryValues(string begin, string end)
        {
            DateTime dateBegin;
            DateTime dateEnd;

            DateTime.TryParse(begin + " 00:00:00", out dateBegin);
            DateTime.TryParse(end + " 23:59:59", out dateEnd);

            var query = from e in db.Entries
                        where e.Date > dateBegin && e.Date < dateEnd
                        select e;


            return null;
        }
    }
}
