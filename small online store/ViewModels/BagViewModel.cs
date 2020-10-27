using small_online_store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace small_online_store.ViewModels
{
    public class BagViewModel
    {
        public Item ItemsModel { get; set; }

        public Order OrderModel { get; set; }

    }
}