using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClaseConPruebaMigraciones;

namespace WebPruebaMvc.Controllers
{
    public class ArticuloesController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Articuloes
        public ActionResult Index()
        {
            return View(db.Articulos.ToList());
        }

        // GET: Articuloes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // GET: Articuloes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articuloes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Autor,Cuerpo")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Articulos.Add(articulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articulo);
        }

        // GET: Articuloes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // POST: Articuloes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Autor,Cuerpo")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(articulo);
        }

        // GET: Articuloes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // POST: Articuloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Articulo articulo = db.Articulos.Find(id);
            db.Articulos.Remove(articulo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //aca se hara un select, buscando el articulo con el id
        public ActionResult listadoComentarios(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo.Comentarios);
        }

        //public ActionResult comentariosPertenecientes(Articulo articulo)
        //{


        //    return View(articulo);

        //}



        //Get, inicio de comentarios, respecto a cada articulo

        public ActionResult ComentarioIndex()
        {
            return View(db.Comentarios.ToList()); //devuelve los datos de los comentarios
        }

        //inicio de el delete, update, agregarComentario
        public ActionResult CreateComentario()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComentario([Bind(Include = "Id,Autor,Cuerpo,ArticuloId,Fecha")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {

                if (db.Articulos.Find(comentario.ArticuloId)==null) {
                    ViewBag.Message = "No se pudo encontrar el articulo relacionado";
                    View();
                    //return RedirectToAction("ComentarioIndex");
                }
                else
                {
                    db.Comentarios.Add(comentario);
                    db.SaveChanges();
                    return RedirectToAction("ComentarioIndex");
                }
            }

            return View(comentario);
        }
        private bool existe(int id)
        {
            bool existe = false;
            foreach (var item in db.Articulos)
            {
                if (item.Id == id)
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }
        private Articulo BuscarArticulo(int id)
        {
            Articulo encontrado = db.Articulos.Find(id);
            return encontrado;
        }
        //accion que se ejecuta en control
        public ActionResult DeleteComentario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario= db.Comentarios.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            if (existe(comentario.ArticuloId))
            {
                Articulo art= db.Articulos.Find(comentario.ArticuloId);
                ViewData["Articulo"] = art.Name;
                ViewBag.Message = null;
            }
            else
            {
                ViewBag.Message = "No se pudo encontrar el articulo";
            }
            return View(comentario);
        }

        [HttpPost, ActionName("DeleteComentario")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedComentario(int id)
        {
            Comentario comentario = db.Comentarios.Find(id);
            db.Comentarios.Remove(comentario);
            db.SaveChanges();
            return RedirectToAction("ComentarioIndex");
        }
        //metodo GET, en este metodo se controlara que el id no sea null
        public ActionResult EditComentario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentarios.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditComentario([Bind(Include = "Id,Autor,Cuerpo,ArticuloId,Fecha")] Comentario comentario)
        {
            if (db.Articulos.Find(comentario.ArticuloId) == null)
            {
                ViewBag.Message = "No se encuentra el id del articulo seleccionado";
                return View(comentario);
            }
            if (ModelState.IsValid)
            {
                
                
                db.Entry(comentario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comentario);
        }

        //inicio de la creacion de el comentario a partir de un id de un articulo
        public ActionResult AnadirComentario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AnadirComentario([Bind(Include = "Id,Autor,Cuerpo,ArticuloId,Fecha")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {

                db.Comentarios.Add(comentario);
                db.SaveChanges();
                return RedirectToAction("listadoComentarios", new { id = comentario.ArticuloId });
            }
            //en caso de que no se haya podido crear el comentario se vuelve a la vista
            ViewBag.Message = "No se pudo agregar el comentario a el articulo seleccionado";
            Articulo art = db.Articulos.Find(comentario.ArticuloId);
            return View(art);
        }

        //se usa para desconectar de la base de datos
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
