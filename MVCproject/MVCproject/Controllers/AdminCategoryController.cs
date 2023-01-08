﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCproject.Controllers
{
    public class AdminCategoryController : Controller
    {
        //Admin sayfasındaki kategori bölümüne sql tablolarını getirme işlemi için AdminCategoryController gitmeliyiz.
        //
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            //Listeleme işlemi
            var Categorvalues = cm.GetList();
            return View(Categorvalues);
        }

        //Sayfa yüklendikten sonra [HttpGet] çalışacak.
        //Aynı isimli ActionResult ın üzerinde çalışacak.
        [HttpGet]
        public ActionResult AddCategory()
        {
            //Sayfayı geri göndürür.
            return View();
        }

        //Yeni kategori eklemek için kullanacağımız metod.
        //Kategori ekleme işleminde üzerinde çalıştığımız entitiden türetilmiş bir parametre göndermemiz gerekiyor.
        //Sayfada bir butona tıkladığımız zaman [HttpPost] çalışacak.
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            //cm.CategoryADDBl(p);


            //CategoryValidator category'in kurallarını tutuyor.
            //CategoryValidator dan bir nesne türetiyoruz.
            CategoryValidator categoryValidator = new CategoryValidator();

            //Validate() geçerliliği kontrol eder.
            //results isminde bir ValidationResult değişkeni oluşturduk.
            //results CategoryValidator dan değerlerle kontrolünü(Validate) yapıyoruz.
            ValidationResult results = categoryValidator.Validate(p);

            //Eğerki results değeri doğrulanmışsa ekleme işlemi gerçekleşir.
            if (results.IsValid)
            {
                cm.CategoryAddBL(p);
                //Ekleme işlemini gerçekleştikten sonra bizi tanımlamış olduğumuz GetCategoryList metoduna yönlendir.
                return RedirectToAction("Index");
            }
            else
            {
                //Hata mesajlarını tutacağımız diziyi oluşturuyoruz.
                //results dan gelen Errors lardan bir döngü oluşturucak
                foreach (var item in results.Errors)
                {
                    //Modelin durumuna hataları ekle(önce ilgili property nin ismi), (hatanın kendisi)
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
    }
    }
}