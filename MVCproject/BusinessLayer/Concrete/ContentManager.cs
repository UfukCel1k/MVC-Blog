﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _ContentDal;

        public ContentManager(IContentDal contentDal)
        {
            _ContentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
            _ContentDal.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            _ContentDal.Delete(content);    
        }

        public void ContentUpdate(Content content)
        {
            _ContentDal.Update(content);    
        }

        public Content GetByID(int id)
        {
            return _ContentDal.Get(x => x.ContetID == id);
        }

            
        public List<Content> GetList()
        {
            return _ContentDal.List();
            throw new NotImplementedException();
        }

        //Bir parametreye bağlı olarak listeleme işlemi yapmak için gerekli şartı çağırmamız gerekiyorz.
        //Filtreleme işlemi.
        public List<Content> GetListByHeadingID(int id)
        {
            return _ContentDal.List(x => x.HeadingID==id);
        }
    }
}
