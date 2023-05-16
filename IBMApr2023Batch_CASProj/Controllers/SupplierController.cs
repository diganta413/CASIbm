using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBMApr2023Batch_CASProj.Models;
using IBMApr2023Batch_CASProj.Models.SecurityModel;

namespace IBMApr2023Batch_CASProj.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        IBMApr2023Batch_CASProj.Models.SecurityModel.CASIbmEntities _db = new IBMApr2023Batch_CASProj.Models.SecurityModel.CASIbmEntities();
        // GET: Supplier
        public ActionResult Index()
        {
            return View(_db.Orders.ToList());
        }
        public ActionResult OrderDetails(int? id)
        {
            Order order = _db.Orders.Find(id);
            return View(order);
        }
    }
}