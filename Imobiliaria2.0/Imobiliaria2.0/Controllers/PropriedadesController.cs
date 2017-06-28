using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Imobiliaria2._0.Models;

namespace Imobiliaria2._0.Controllers
{
    public class PropriedadesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Propriedades
        //public ActionResult Index()
        //{
        //    var propriedades = db.Propriedades.Include(p => p._Proprietario);
        //    return View(propriedades.ToList());
        //}

        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            // ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var propriedades = from s in db.Propriedades
                               select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                propriedades = propriedades.Where(s => s.Endereco.Contains(searchString)
                                      // || s.FirstMidName.Contains(searchString));
                                      );
            }
            switch (sortOrder)
            {
                case "name_desc":
                    propriedades = propriedades.OrderByDescending(s => s.Endereco);
                    break;
                //case "Date":
                //    students = students.OrderBy(s => s.EnrollmentDate);
                //    break;
                //case "date_desc":
                //    students = students.OrderByDescending(s => s.EnrollmentDate);
                //    break;
                default:
                    propriedades = propriedades.OrderBy(s => s.Endereco);
                    break;
            }

            return View(propriedades.ToList());
        }


        // GET: Propriedades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propriedade propriedade = db.Propriedades.Find(id);
            if (propriedade == null)
            {
                return HttpNotFound();
            }
            return View(propriedade);
        }

        // GET: Propriedades/Create
        public ActionResult Create()
        {
            ViewBag.ProprietarioID = new SelectList(db.Proprietarios, "Id", "Nome");
            return View();
        }

        // POST: Propriedades/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Endereco,Cep,Descricao,Preco,Material,Ativo,ProprietarioID,Situacao")] Propriedade propriedade)
        {
            if (ModelState.IsValid)
            {
                db.Propriedades.Add(propriedade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProprietarioID = new SelectList(db.Proprietarios, "Id", "Nome", propriedade.ProprietarioID);
            return View(propriedade);
        }

        // GET: Propriedades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propriedade propriedade = db.Propriedades.Find(id);
            if (propriedade == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProprietarioID = new SelectList(db.Proprietarios, "Id", "Nome", propriedade.ProprietarioID);
            return View(propriedade);
        }

        // POST: Propriedades/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Endereco,Cep,Descricao,Preco,Material,Ativo,ProprietarioID,Situacao")] Propriedade propriedade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propriedade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProprietarioID = new SelectList(db.Proprietarios, "Id", "Nome", propriedade.ProprietarioID);
            return View(propriedade);
        }

        // GET: Propriedades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propriedade propriedade = db.Propriedades.Find(id);
            if (propriedade == null)
            {
                return HttpNotFound();
            }
            return View(propriedade);
        }

        // POST: Propriedades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Propriedade propriedade = db.Propriedades.Find(id);
            db.Propriedades.Remove(propriedade);
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
    }
}
