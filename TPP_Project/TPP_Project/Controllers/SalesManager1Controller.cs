using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using TPP_Project.Models;
using TPP_Project.Models.entities;
using TPP_Project.Models.repository;

namespace TPP_Project.Controllers
{
    public class SalesManagerController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private ApplicationDbContext _db = new ApplicationDbContext();

        //
        // GET: SalesManager
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var productItemList = new Collection<ProductItem>();
            var productI = from s in _db.ProductItems
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                productI = productI.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    productI = productI.OrderByDescending(s => s.Name);
                    break;
                default:
                    productI = productI.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(productI.ToPagedList(pageNumber, pageSize));
        }
        // GET: SalesManager/Create
        public ActionResult Create()
        {
            //запит на створення елементу
            return View();
        }

        // POST: SalesManager/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,shortDescription,description,price")] ProductItem productItem)
        {
            if (ModelState.IsValid)
            {
                //новий елемент в базу, зі всіма полями
                unitOfWork.ProductItemRepository.Insert(productItem);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(productItem);
        }
        // GET: SalesManager/Edit
        public ActionResult Edit(int? id)
        {
            //запит на редагування інформації елементу
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductItem productItem = unitOfWork.ProductItemRepository.GetByID(id);
            if (productItem == null)
            {
                return HttpNotFound();
            }
            return View(productItem);
        }

        // POST: SalesManager/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductItem productItem)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ProductItemRepository.Update(productItem);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(productItem);
        }

        // GET: SalesManager/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //отримуємо елемент
            ProductItem productItem = unitOfWork.ProductItemRepository.GetByID(id);
            if (productItem == null)
            {
                return HttpNotFound();
            }
            return View(productItem);
        }

        // POST: SalesManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //видалення елемента
            ProductItem productItem = unitOfWork.ProductItemRepository.GetByID(id);
            unitOfWork.ProductItemRepository.Delete(productItem);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

    }
}
