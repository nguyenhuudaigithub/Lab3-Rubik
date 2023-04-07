using lab_3.Models;
using Microsoft.Ajax.Utilities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace lab_3.Controllers
{
    public class RubikController : Controller
    {
        Model1 data = new Model1();
        // GET: Rubik
        public ActionResult Index(int? page,string searchString)
        {
            ViewBag.Keyword = searchString;
            if (page == null)
                page = 1;
            int pageSize = 3;
            return View(Rubik.GetAll(searchString).ToPagedList(page.Value,pageSize));
        }
        
        
        
        public ActionResult Detail(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Rubik find = Rubik.FindRubikByid(id.Value);
            if (find == null)
                return HttpNotFound();
            return View(find);
        }
        public ActionResult Create()
        {
            return View(new Rubik());
        }

        [HttpPost]
        public ActionResult Create(Rubik newRubik)
        {
            if (ModelState.IsValid)
            {
                
                newRubik.Insert();

                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", newRubik);
            }
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }



        public ActionResult Edit(int id)
        {
            var E_sach = data.Rubiks.First(m => m.id == id);
            return View(E_sach);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_rubik = data.Rubiks.First(m => m.id == id);
            var E_ten = collection["ten"];
            var E_mota = collection["mota"];
            var E_hang = collection["hang"];
            var E_gia = Convert.ToDecimal(collection["giaban"]);
            var E_hinh = collection["hinh"];
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycapnhat"]);
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            E_rubik.id = id;
            if (string.IsNullOrEmpty(E_ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_rubik.ten = E_ten.ToString();
                E_rubik.mota = E_mota.ToString();
                E_rubik.hang = E_hang.ToString();
                E_rubik.gia = E_gia;
                E_rubik.hinh = E_hinh.ToString();
                E_rubik.ngaycapnhat = E_ngaycapnhat;
                E_rubik.soluongton = E_soluongton;
                UpdateModel(E_rubik);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }



        public ActionResult Delete(int? id)
        {
            Model1 context = new Model1();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rubik rb = context.Rubiks.Find(id);
            if (rb == null)
            {
                return HttpNotFound();
            }
            return View(rb);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Model1 context = new Model1();
            Rubik rb = context.Rubiks.Find(id);
            context.Rubiks.Remove(rb);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}