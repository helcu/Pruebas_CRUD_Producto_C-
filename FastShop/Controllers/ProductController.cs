using FastShop.Context;
using FastShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FastShop.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string user, string pass)
        {
            User usero = new User();
            usero.user = user;
            usero.pass = pass;

            try
            {
                if (ModelState.IsValid)
                {
                    bool r = ProductContext.Instance.verifyUser(usero);
                   if (r==true)
                             return RedirectToAction("Index");
                   else
                        return View();

                }
                return View(user);
                
            }
            catch(Exception ex)
            {
                return View();
            }

           
        }



        // GET: Product
        public ActionResult Index()
        {
            return View(ProductContext.Instance.List.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = ProductContext.instance.find(id);
            if (product == null)
                return HttpNotFound();
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    ProductContext.Instance.Add(product);

                    return RedirectToAction("Index");
                }

                return View(product);
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Product product = ProductContext.instance.find(id);
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    ProductContext.instance.modify(product);
                    return RedirectToAction("Index");
                }

                return View(product);
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id==null)
                   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Product product = ProductContext.instance.find(id);
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Product prod)
        {
            try
            {
                Product product = new Product();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                    product = ProductContext.instance.find(id);
                    if (product == null)
                        return HttpNotFound();
                    ProductContext.instance.delete(product);
                    return RedirectToAction("Index");
                }

                return View(product);
            }
            catch
            {
                return View();
            }
        }
    }
}
