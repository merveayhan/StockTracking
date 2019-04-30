using StockTracking.Model.Option;
using StockTracking.Service.Option;
using StockTracking.UI.Areas.Admin.Models.DTO;
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
            List<Category> model = _categoryService.GetActive();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Product data, HttpPostedFileBase Image)
        {
            List<string> UploadedImagePaths = new List<string>();

            UploadedImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.UserImage = UploadedImagePaths[0];

            if (data.UserImage == "0" || data.UserImage == "1" || data.UserImage == "2")
            {
                data.UserImage = ImageUploader.DefaultProfileImagePath;
                data.XSmallUserImage = ImageUploader.DefaultXSmallProfileImage;
                data.CruptedUserImage = ImageUploader.DefaulCruptedProfileImage;
            }
            else
            {
                data.XSmallUserImage = UploadedImagePaths[1];
                data.CruptedUserImage = UploadedImagePaths[2];
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
            List<Category> categories = _categoryService.GetActive();
            Product product = _productService.GetByID(id);
            ProductDTO model = new ProductDTO();
            model.ID = product.ID;
            model.ProductName = product.ProductName;
            model.Quantity = product.Quantity;
            model.Kdv = product.Kdv;
            model.FirstPrice = product.FirstPrice;
            model.SalePrice = product.SalePrice;
            model.Categories = categories;



            model.UserImage = product.UserImage;
            model.XSmallUserImage = product.XSmallUserImage;
            model.CruptedUserImage = product.CruptedUserImage;

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(ProductDTO data, HttpPostedFileBase Image)
        {

            List<string> UploadedImagePaths = new List<string>();

            UploadedImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.UserImage = UploadedImagePaths[0];


            Product update = _productService.GetByID(data.ID);

            if (data.UserImage == "0" || data.UserImage == "1" || data.UserImage == "2")
            {

                if (update.UserImage == null || update.UserImage == ImageUploader.DefaultProfileImagePath)
                {
                    update.UserImage = ImageUploader.DefaultProfileImagePath;
                    update.XSmallUserImage = ImageUploader.DefaultXSmallProfileImage;
                    update.CruptedUserImage = ImageUploader.DefaulCruptedProfileImage;
                }
                else
                {
                    update.UserImage = update.UserImage;
                    update.XSmallUserImage = update.XSmallUserImage;
                    update.CruptedUserImage = update.CruptedUserImage;
                }

            }
            else
            {
                update.UserImage = UploadedImagePaths[0];
                update.XSmallUserImage = UploadedImagePaths[1];
                update.CruptedUserImage = UploadedImagePaths[2];
            }

            update.ProductName = data.ProductName;
            update.Quantity = data.Quantity;
            update.Kdv = data.Kdv;
            update.FirstPrice = data.FirstPrice;
            update.SalePrice = data.SalePrice;
            update.AddDate = data.AddDate;
            // update.ImagePath = data.ImagePath;

            _productService.Update(update);

            return Redirect("/Admin/Product/List");


        }

        public ActionResult Delete(Guid id)
        {
            _productService.Remove(id);
            return Redirect("/Admin/Product/List");
        }
    }
}