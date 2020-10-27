using small_online_store.Models;
using small_online_store.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace small_online_store.Controllers
{
    public class ClothingController : Controller
    {
        // GET: Clothing
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        

        [HttpGet]
        public ActionResult MenClothing(string id)
        {
            Items db = new Items();
            ClothingViewModel ViewModel = new ClothingViewModel();
            List<string> brands = db.ItemsUnites.Select(x => x.Brand).Distinct().ToList();
            List<SelectListItem> listOfBrands = new List<SelectListItem>();
            foreach (var item in brands)
            {
                SelectListItem selectItem = new SelectListItem
                {
                    Text = item,
                    Value = item
                };
                listOfBrands.Add(selectItem);
            }
            List<string> colors = db.ItemsUnites.Select(x => x.Color).Distinct().ToList();
            List<SelectListItem> listOfColors = new List<SelectListItem>();
            foreach (var item in colors)
            {
                SelectListItem selectItem = new SelectListItem
                {
                    Text = item,
                    Value = item
                };
                listOfColors.Add(selectItem);
            }
            List<SelectListItem> listOfSort = new List<SelectListItem>
            {   
                new SelectListItem {Text="Recommended",Value="Recommended",Selected=true},
                new SelectListItem {Text="High to Low",Value="High"},
                new SelectListItem {Text="Low to High",Value="Low"}
            };

            List<Item> clothes = new List<Item>();
            clothes = db.ItemsUnites.ToList();


            ViewModel.ItemsModel = clothes;
            ViewModel.BrandItems = listOfBrands;
            ViewModel.SortItems = listOfSort;
            ViewModel.ColorItems = listOfColors;
            return View(ViewModel);
        }
        [HttpPost]
        public ActionResult MenClothing(ClothingViewModel model)
        {
            Items db = new Items();
            //filter brands
            List<string> brands = db.ItemsUnites.Select(x => x.Brand).Distinct().ToList();
            List<SelectListItem> listOfBrands = new List<SelectListItem>();
            foreach (var item in brands)
            {
                SelectListItem selectItem = new SelectListItem
                {
                    Text = item,
                    Value = item
                };
                listOfBrands.Add(selectItem);
            }
            //filter colors
            List<string> colors = db.ItemsUnites.Select(x => x.Color).Distinct().ToList();
            List<SelectListItem> listOfColors = new List<SelectListItem>();
            foreach (var item in colors)
            {
                SelectListItem selectItem = new SelectListItem
                {
                    Text = item,
                    Value = item
                };
                listOfColors.Add(selectItem);
            }
            //sort by list
            List<SelectListItem> listOfSort = new List<SelectListItem>
            {
                new SelectListItem {Text="Recommended",Value="Recommended",Selected=true},
                new SelectListItem {Text="High to Low",Value="High"},
                new SelectListItem {Text="Low to High",Value="Low"}
            };

            //items for sale
            List<Item> clothes = new List<Item>();
            

            if (model.Colors != null)
            {
                foreach (var item in model.Colors)
                {
                    List<Item> newList = db.ItemsUnites.Where(x => x.Color == item).ToList();
                    clothes.AddRange(newList);
                }
            }
            if (model.Brands != null)
            {
                foreach (var item in model.Brands)
                {
                    List<Item> newList = db.ItemsUnites.Where(x => x.Brand == item).ToList();
                    clothes.AddRange(newList);
                }
            }
            if (model.Brands == null && model.Colors == null)
            {
                clothes = db.ItemsUnites.ToList();
                    
            }
            clothes = clothes.Distinct().ToList();

            if (model.Sorts == "High") { clothes = clothes.OrderByDescending(x => x.Price).ToList(); }
            if (model.Sorts == "Low") { clothes = clothes.OrderBy(x => x.Price).ToList(); }
            model.ItemsModel = clothes;
            model.SortItems = listOfSort;
            model.BrandItems = listOfBrands;
            model.ColorItems = listOfColors;
            return View(model);
        }
        public ActionResult WomenClothing(string type)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Buy(int id)
        {
            Items db = new Items();
            Item item = db.ItemsUnites.Single (x => x.Id == id);
            BagViewModel bvm = new BagViewModel();
            bvm.ItemsModel = item;
            return View(bvm);
        }

        [HttpPost]
        public ActionResult Buy(BagViewModel bag)
        {
            if (small_online_store.Models.CurrentUser.instance != null)
            {
                Order order = new Order();
                order.Quantity = 1;
                order.Size = bag.OrderModel.Size;
                order.ItemId = bag.ItemsModel.Id;
                return RedirectToAction("Create", "Orders", order);
            }
            else
                return RedirectToAction("Create", "Users");

        }
    }
}