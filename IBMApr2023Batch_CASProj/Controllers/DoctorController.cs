using IBMApr2023Batch_CASProj.Models;
using IBMApr2023Batch_CASProj.Models.SecurityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IBM_CAS.Controllers
{
    [Authorize]
    public class DoctorController : Controller
    {
        IBMApr2023Batch_CASProj.Models.SecurityModel.CASIbmEntities _db = new IBMApr2023Batch_CASProj.Models.SecurityModel.CASIbmEntities();
        // GET: Doctor
        public ActionResult Index()
        {
            return RedirectToAction("ListPatients");
        }

        public ActionResult ListPatients()
        {
            return View(_db.Patients.Include("User").ToList());
        }

        public ActionResult Inventory()
        {
            return View(_db.Drugs.ToList());
        }

        public ActionResult AddNewOrder()
        {
            //getting suppliers
            var s = _db.Suppliers.ToList();
            var d = _db.Drugs.ToList();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var c in s)
            {
                list.Add(new SelectListItem
                {
                    Text = c.SupplierFirstName,
                    Value = c.SupplierId.ToString(),
                });
            }
            //getting salesman
            var sl = _db.Salesmen.ToList();
            List<SelectListItem> list1 = new List<SelectListItem>();
            foreach (var c1 in sl)
            {
                list1.Add(new SelectListItem
                {
                    Text = c1.SalesmanFirstName,
                    Value = c1.SalesmanId.ToString(),
                });
            }
            ViewBag.suppliers = list;
            ViewBag.salesmen = list1;
            ViewBag.Drugs = _db.Drugs.Select(s1 => new { s1.DrugId, s1.DrugName });
            return View();
        }
        [HttpPost]
        public ActionResult AddNewOrder(OrderViewModel order, List<OrderItemViewModel> Orderitems)
        {
            Order newOrder = new Order { OrderDate = order.OrderDate, OrderDescription = order.OrderDesc };

            newOrder.Supplier = _db.Suppliers.Find(order.SupplierId);
            newOrder.Salesman = _db.Salesmen.Find(order.SalesmanID);

            foreach (OrderItemViewModel item in Orderitems)
            {
                var ord = new OrderItem { Quantity = item.Quantity };
                ord.Drug = _db.Drugs.Find(item.DrugId);
                newOrder.OrderItems.Add(ord);
                
            }
            _db.Orders.Add(newOrder);
            _db.SaveChanges();
            return RedirectToAction("Index","Doctor");
        }

    }
    
    
}