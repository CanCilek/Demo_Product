using System;
using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDAL _productDal;

        public ProductManager(IProductDAL productDal)
        {
            _productDal = productDal;
        }

        public void TDelete(Product t)
        {
            _productDal.Delete(t);
        }

        public Product TGetById(int Id)
        {
            return _productDal.GetById(Id);
        }

        public List<Product> TGetList()
        {
            return _productDal.GetList();
        }

        public void TInsert(Product t)
        {
            //Bunları FluentValidation da oluşturacağız

            //if(t.Name.Length >= 5 && t.Price >= 1 && t.Name != null)
            //{
            //    _productDal.Insert(t);
            //}
            //else
            //{
            //    //Hata Mesajları Yazılabilir.
            //}
            _productDal.Insert(t);
            
        }

        public void TUpdate(Product t)
        {
            _productDal.Update(t);
        }
    }
}

