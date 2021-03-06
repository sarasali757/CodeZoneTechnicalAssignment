using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Models;
namespace Store.ViewModels
{
    public class PurchaseItems
    {
        public List<Item> items { get; set; }
        public Purchase purchase { get; set; }
    }
}