using Imobiliaria2._0.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Imobiliaria2._0.Controllers
{
    public class ProprietariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Categorias (GET = Carregamento Da Pagina)
        public ActionResult Index()
        {
            //List<Proprietario> proprietario = new List<Proprietario>();
            var proprietarios = db.Proprietarios;
            return View(proprietarios.ToList());
            //Retornar A Lista de Objetos Cadastrados
            //return View(proprietario);
        }

        //GET
        public ActionResult Create()
        {

            return View();
        }

        //Post
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Nome,Endereco,Rg,Cpf,Telefone,MatriculaImovel,InscricaoImovel,Ativo")]Proprietario proprietario)// FormCollection campos (Recuperar Campo A Campo Sem Model)
        {
            if (ModelState.IsValid)
            {
                //Insert
                db.Proprietarios.Add(proprietario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proprietario);
        }

        //GET
        public ActionResult Edit(int? id)
        {
            //Verificar Se Veio Id => BadRequest
            if (id == null)
            {
                //Erro - 400
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Pesquisa na Fonte de Dados o Objeto a Editar

            Proprietario proprietario = db.Proprietarios.Find(id);

            //Se Objeto não foi Encontrado na Fonte De Dados
            if (proprietario == null)
            {
                //Erro - 404
                return HttpNotFound();
            }

            return View(proprietario);
        }

        //Post
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Nome,Endereco,Rg,Cpf,Telefone,MatriculaImovel,InscricaoImovel,Ativo")]Proprietario proprietario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(proprietario).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(proprietario);
        }

        //GET
        public ActionResult Delete(int? id)

        { 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprietario proprietario = db.Proprietarios.Find(id);
            if (proprietario == null)
            {
                return HttpNotFound();
            }
            return View(proprietario);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            //Pesquisar Objeto Por Id

            Proprietario proprietario = db.Proprietarios.Find(id);
            db.Proprietarios.Remove(proprietario);
            db.SaveChanges();
            return RedirectToAction("Index");

            //TempData["Mensagem"] = "Proprietario Excluida Com Sucesso";
        }
    }
}