using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using small_online_store.Models;
using small_online_store.ViewModels;

namespace small_online_store.Controllers
{
    public class OrdersController : Controller
    {
        private UsersDataModel db = new UsersDataModel();

        // GET: Orders
        public async Task<ActionResult> Index(int userId)
        {

            var q = (from pd in db.Orders
                                    join od in db.Bags on pd.Id equals od.OrderId where od.UserId == userId

                                    select new
                                    {
                                        pd.Id,
                                        pd.ItemId,
                                        pd.Size,
                                        pd.Quantity

                                    }).Select(x => new notMapedOrder { Id = x.Id, ItemId = x.ItemId, Size = x.Size, Quantity = x.Quantity }).ToList();


            return View(q);
        }

        // GET: Orders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_get(Order order)
        {
            return View(order);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create_post([Bind(Include = "Id,ItemId,Size,Quantity")] Order order)
        {
            Bag bag = new Bag();
            bag.OrderId = order.Id;
            bag.UserId = CurrentUser.instance.Id;
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.Bags.Add(bag);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { userId = @small_online_store.Models.CurrentUser.instance.Id });
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ItemId,Size,Quantity")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index",new { userId = @small_online_store.Models.CurrentUser.instance.Id } );
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            List<Bag> bags = db.Bags.Where(x => x.OrderId == id).ToList();
            foreach (var bag in bags) { db.Bags.Remove(bag); }
            Order order = await db.Orders.FindAsync(id);
            db.Orders.Remove(order);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", new { userId = @small_online_store.Models.CurrentUser.instance.Id });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
