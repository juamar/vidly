using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            return View(new LayoutViewModel());
        }

        public ActionResult Details(int id)
        {
            LayoutViewModel viewModel = new LayoutViewModel();
            viewModel.CustomerSelected = id;

            //We Shall check if customer really exists...
            foreach (Customer customer in viewModel.Customers)
            {
                if ( id == customer.Id )
                {
                    return View(viewModel);
                }
            }

            return HttpNotFound();
            
        }
    }
}