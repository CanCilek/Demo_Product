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

        void IGenericService<Product>.TDelete(Product t)
        {
            _productDal.Delete(t);
        }

        Product IGenericService<Product>.TGetById(int Id)
        {
            return _productDal.GetById(Id);
        }

        List<Product> IGenericService<Product>.TGetList()
        {
            return _productDal.GetList();
        }

        void IGenericService<Product>.TInsert(Product t)
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

        void IGenericService<Product>.TUpdate(Product t)
        {
            _productDal.Update(t);
        }
    }
}

