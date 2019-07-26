using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScraperApplication.Models;

namespace ScraperApplication.Controllers
{
    public class stockDataController : Controller
    {
        private stockEntity db = new stockEntity();

        // GET: stockData
        public async Task<ActionResult> Index()
        {
            return View(await db.stockDatas.ToListAsync());
        }

        // GET: stockData/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stockData stockData = await db.stockDatas.FindAsync(id);
            if (stockData == null)
            {
                return HttpNotFound();
            }
            return View(stockData);
        }

        // GET: stockData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: stockData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Symbol,LastPrice,Change,PChg,Currency,MarketTime,VolumeAvg")] stockData stockData)
        {
            if (ModelState.IsValid)
            {
                db.stockDatas.Add(stockData);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(stockData);
        }

        // GET: stockData/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stockData stockData = await db.stockDatas.FindAsync(id);
            if (stockData == null)
            {
                return HttpNotFound();
            }
            return View(stockData);
        }

        // POST: stockData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Symbol,LastPrice,Change,PChg,Currency,MarketTime,VolumeAvg")] stockData stockData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockData).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(stockData);
        }

        // GET: stockData/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stockData stockData = await db.stockDatas.FindAsync(id);
            if (stockData == null)
            {
                return HttpNotFound();
            }
            return View(stockData);
        }

        // POST: stockData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            stockData stockData = await db.stockDatas.FindAsync(id);
            db.stockDatas.Remove(stockData);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
