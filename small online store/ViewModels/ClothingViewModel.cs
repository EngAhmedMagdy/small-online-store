using small_online_store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace small_online_store.ViewModels
{
    public class ClothingViewModel
    {
        public IEnumerable<Item> ItemsModel { get; set; }

        public IEnumerable<SelectListItem> BrandItems { get; set; }

        public IEnumerable<SelectListItem> SortItems { get; set; }

        public IEnumerable<SelectListItem> ColorItems { get; set; }

        public IEnumerable<string> Brands  { get; set; }
        public IEnumerable<string> Colors { get; set; }
        public string Sorts { get; set; }
    }
}