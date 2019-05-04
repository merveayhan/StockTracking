using StockTracking.Model.Option;
using StockTracking.Service.Option;
using StockTracking.UI.Areas.Admin.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockTracking.UI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryService();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category data)
        {
            _categoryService.Add(data);
            return Redirect("/Admin/Category/List");
        }

        public ActionResult List()
        {
            List<Category> model = _categoryService.GetActive();
            return View(model);
        }

        public ActionResult Update(Guid id)
        {
            Category cat = _categoryService.GetByID(id);
            CategoryDTO model = new CategoryDTO();
            model.ID = cat.ID;
            model.CategoryName = cat.CategoryName;
            model.Description = cat.Description;
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(CategoryDTO data)
        {
            Category cat = _categoryService.GetByID(data.ID);
            cat.CategoryName = data.CategoryName;
            cat.Description = data.Description;
            _categoryService.Update(cat);
            return Redirect("/Admin/Category/List");
        }

        public ActionResult Delete(Guid id)
        {
            _categoryService.Remove(id);
            return Redirect("/Admin/Category/List");
        }
        //public JsonResult Delete(Guid id)
        //{
        //    Category category = _categoryService.GetByID(id) ;
        //    category.Status = StockTracking.Core.Enum.Status.Deleted;
        //    category.ModifiedDate = DateTime.Now;
        //    _categoryService.Remove(id);
        //    return Json("/Admin/Category/List");
        //}

    }
}