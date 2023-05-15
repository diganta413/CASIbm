using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IBMApr2023Batch_CASProj.Models
{
    public class OrderViewModel
    {
        public string OrderDesc { get; set; }
        public int SupplierId { get; set; }
        public int SalesmanID { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
    }

    public class OrderItemViewModel
    {
        public int DrugId { get; set; }
        public int Quantity { get; set; }
    }
}