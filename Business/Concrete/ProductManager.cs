﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{

    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        //Injection
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //Business codes : Kurallar, izinler, yetkiler
            if (product.ProductName.Length < 2)
            {
                //magic string : standart olmayan mesajlar
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //İş kodları
            //Yetkisi var mı? (Kurallar)

            if (DateTime.Now.Hour==22)
            {
                //sistem bakım zamanı olduğu için sadece mesaj döner
                //Product listesi default(null) döner
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

           return new 
                SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
