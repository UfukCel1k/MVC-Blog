﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    //CategoryManager olarak interfacenin de tanımlı metodları kalıtsal yollarla çağırıyoruz..
    public class CategoryManager : ICategoryService
    {
        //ICategoryDal dan bir _categoryDal ismine bir field türet.
        ICategoryDal _categoryDal;

        //Constructor metodunu hazır getirmek için CategoryManager üzerine (ctrl + .) yaptıktan sonra (Generate constructor) seçiyoruz. Çıkan ekran ok diyerek constructor ı oluştutyoruz.
        public CategoryManager(ICategoryDal categoryDal)
        {
            //_categoryDal a ICategoryDal dan başka categoryDal değerinin ataması gerçekleşmiş oldu. 
            _categoryDal = categoryDal;
        }

        public void CategoryAddBL(Category category)
        {   //Ekleme işlemi için insert kullanıyoruz.
            _categoryDal.Insert(category);
        }

        //Listeleme işlemi
        public List<Category> GetList()
        {
            return _categoryDal.List();
        }


    }
}
        
