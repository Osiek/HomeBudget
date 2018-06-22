using HomeBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Controllers
{
    class TransactionController : BaseController
    {
        private CategoryController categoryController;
        private ShopController shopController;

        public TransactionController()
        {
            shopController = new ShopController();
        }

        public void Add()
        {

        }

        public List<Shop> GetAllShops()
        {
            return shopController.GetAll();
        }
    }
}
