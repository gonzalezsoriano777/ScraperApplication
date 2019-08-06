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
    public class ParsingTablesController : Controller
    {
        private ParsingOfDataEntities db = new ParsingOfDataEntities();

        // GET: ParsingTables
        public async Task<ActionResult> Index()
        {
            return View(await db.ParsingTables.ToListAsync());
        }

        // GET: ParsingTables/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParsingTable parsingTable = await db.ParsingTables.FindAsync(id);
            if (parsingTable == null)
            {
                return HttpNotFound();
            }
            return View(parsingTable);
        }

        // GET: ParsingTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParsingTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,StockRecord,Symbol,Company,LastSale,Change,PChg,VolumeAvg")] ParsingTable parsingTable)
        {
            if (ModelState.IsValid)
            {
                db.ParsingTables.Add(parsingTable);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(parsingTable);
        }

        // GET: ParsingTables/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParsingTable parsingTable = await db.ParsingTables.FindAsync(id);
            if (parsingTable == null)
            {
                return HttpNotFound();
            }
            return View(parsingTable);
        }

        // POST: ParsingTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,StockRecord,Symbol,Company,LastSale,Change,PChg,VolumeAvg")] ParsingTable parsingTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parsingTable).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(parsingTable);
        }

        // GET: ParsingTables/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParsingTable parsingTable = await db.ParsingTables.FindAsync(id);
            if (parsingTable == null)
            {
                return HttpNotFound();
            }
            return View(parsingTable);
        }

        // POST: ParsingTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ParsingTable parsingTable = await db.ParsingTables.FindAsync(id);
            db.ParsingTables.Remove(parsingTable);
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
