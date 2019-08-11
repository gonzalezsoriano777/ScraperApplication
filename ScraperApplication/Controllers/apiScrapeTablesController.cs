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
    public class apiScrapeTablesController : Controller
    {
        private apiDatabaseEntities db = new apiDatabaseEntities();

        // GET: apiScrapeTables
        public async Task<ActionResult> Index()
        {
            return View(await db.apiScrapeTables.ToListAsync());
        }

        // GET: apiScrapeTables/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            apiScrapeTable apiScrapeTable = await db.apiScrapeTables.FindAsync(id);
            if (apiScrapeTable == null)
            {
                return HttpNotFound();
            }
            return View(apiScrapeTable);
        }

        // GET: apiScrapeTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: apiScrapeTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,StockRecord,Symbol,LastPrice,PercentChange,MarketChange")] apiScrapeTable apiScrapeTable)
        {
            if (ModelState.IsValid)
            {
                db.apiScrapeTables.Add(apiScrapeTable);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(apiScrapeTable);
        }

        // GET: apiScrapeTables/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            apiScrapeTable apiScrapeTable = await db.apiScrapeTables.FindAsync(id);
            if (apiScrapeTable == null)
            {
                return HttpNotFound();
            }
            return View(apiScrapeTable);
        }

        // POST: apiScrapeTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,StockRecord,Symbol,LastPrice,PercentChange,MarketChange")] apiScrapeTable apiScrapeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apiScrapeTable).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(apiScrapeTable);
        }

        // GET: apiScrapeTables/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            apiScrapeTable apiScrapeTable = await db.apiScrapeTables.FindAsync(id);
            if (apiScrapeTable == null)
            {
                return HttpNotFound();
            }
            return View(apiScrapeTable);
        }

        // POST: apiScrapeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            apiScrapeTable apiScrapeTable = await db.apiScrapeTables.FindAsync(id);
            db.apiScrapeTables.Remove(apiScrapeTable);
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

        public ActionResult Request()
        {


            return RedirectToAction("Index");

        }
    }
}
