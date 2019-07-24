using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScraperApplication.Models;
using ScraperApplication.ScrapingData;


namespace ScraperApplication.Controllers
{
    public class StockTablesController : Controller
    {
        private stockDatabaseEntities db = new stockDatabaseEntities();

        // GET: StockTables
        public ActionResult Index()
        {
            return View(db.StockTables.ToList());
        }

        // GET: StockTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTable stockTable = db.StockTables.Find(id);
            if (stockTable == null)
            {
                return HttpNotFound();
            }
            return View(stockTable);
        }

        // GET: StockTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StockTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StockRecord,Symbol,LastPrice,Change,PChg,Currency,MarketTime,VolumeAvg")] StockTable stockTable)
        {
            if (ModelState.IsValid)
            {
                db.StockTables.Add(stockTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stockTable);
        }

        // GET: StockTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTable stockTable = db.StockTables.Find(id);
            if (stockTable == null)
            {
                return HttpNotFound();
            }
            return View(stockTable);
        }

        // POST: StockTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StockRecord,Symbol,LastPrice,Change,PChg,Currency,MarketTime,VolumeAvg")] StockTable stockTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stockTable);
        }

        // GET: StockTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTable stockTable = db.StockTables.Find(id);
            if (stockTable == null)
            {
                return HttpNotFound();
            }
            return View(stockTable);
        }

        // POST: StockTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockTable stockTable = db.StockTables.Find(id);
            db.StockTables.Remove(stockTable);
            db.SaveChanges();
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

        public ActionResult Scrape()
        {
            Scraping buttonExecution = new Scraping();
            buttonExecution.LogginIn();
            buttonExecution.TransitionToPortfolio();
            buttonExecution.InsertingData();


            return RedirectToAction("Index");
        }
    }
}
