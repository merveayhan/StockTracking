using StockTracking.Model.Option;
using StockTracking.Service.Option;
using StockTracking.UI.Areas.Admin.Models.DTO;
using StockTracking.UI.Areas.Admin.Models.VM;
using StockTracking.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockTracking.UI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        CategoryService _categoryService;
        ProductService _productService;
        public ProductController()
        {
            _categoryService = new CategoryService();
            _productService = new ProductService();
        }

        public ActionResult Add()
        {
            //List<Category> model = _categoryService.GetActive();
            //return View(model);
            ProductVM model = new ProductVM()
            {
                Categories = _categoryService.GetActive(),          
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Product data, HttpPostedFileBase Image)
        {
            List<string> UploadedImagePaths = new List<string>();

            UploadedImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.ImagePath = UploadedImagePaths[0];

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
            {
                data.ImagePath = ImageUploader.DefaultProfileImagePath;
                data.ImagePath = ImageUploader.DefaultXSmallProfileImage;
                data.ImagePath = ImageUploader.DefaulCruptedProfileImage;
                //data.UserImage = ImageUploader.DefaultProfileImagePath;
                //data.XSmallUserImage = ImageUploader.DefaultXSmallProfileImage;
                //data.CruptedUserImage = ImageUploader.DefaulCruptedProfileImage;
            }
            else
            {             
                data.ImagePath = UploadedImagePaths[1];
                data.ImagePath = UploadedImagePaths[2];
                //data.XSmallUserImage = UploadedImagePaths[1];
                //data.CruptedUserImage = UploadedImagePaths[2];
            }

            data.Status = Core.Enum.Status.Active;

            _productService.Add(data);

            return Redirect("/Admin/Product/List");
        }


        public ActionResult List()
        {
            List<Product> model = _productService.GetActive();
            return View(model);
        }

        public ActionResult Update(Guid id)
        {
           
            Product product = _productService.GetByID(id);
            ProductVM model = new ProductVM();
            model.Product.ID = product.ID;
            model.Product.ProductName = product.ProductName;
            model.Product.Quantity = product.Quantity;
            model.Product.Kdv = product.Kdv;
            model.Product.FirstPrice = product.FirstPrice;
            model.Product.SalePrice = product.SalePrice;
            model.Product.AddDate = product.AddDate;
            model.Product.ImagePath = product.ImagePath;
            List<Category> categories = _categoryService.GetActive();
            model.Categories =categories;

          

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(ProductDTO data, HttpPostedFileBase Image)
        {

            List<string> UploadedImagePaths = new List<string>();

            UploadedImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.ImagePath = UploadedImagePaths[0];


            Product update = _productService.GetByID(data.ID);

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
            {
                
                if (update.ImagePath == null || update.ImagePath == ImageUploader.DefaultProfileImagePath)
                {
                    update.ImagePath = ImageUploader.DefaultProfileImagePath;
                    update.ImagePath = ImageUploader.DefaultXSmallProfileImage;
                    update.ImagePath = ImageUploader.DefaulCruptedProfileImage;
                   
                }
                else
                {
                    update.ImagePath = data.ImagePath;
                    
                }

            }
            else
            {
                update.ImagePath = UploadedImagePaths[0];
                update.ImagePath = UploadedImagePaths[1];
                update.ImagePath = UploadedImagePaths[2];
               
            }

            update.ProductName = data.ProductName;
            update.Quantity = data.Quantity;
            update.Kdv = data.Kdv;
            update.FirstPrice = data.FirstPrice;
            update.SalePrice = data.SalePrice;
            update.AddDate = data.AddDate;
            update.ImagePath = data.ImagePath;
            update.CategoryID = data.CategoryID;

            _productService.Update(update) ;

            return Redirect("/Admin/Product/List");


        }

        public ActionResult Delete(Guid id)
        {
            _productService.Remove(id);
            return Redirect("/Admin/Product/List");
        }
    }
}