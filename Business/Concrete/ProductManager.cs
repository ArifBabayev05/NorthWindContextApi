using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ILogger _logger;

        public ProductManager(IProductDal productDal, ILogger logger)
        {
            _productDal = productDal;
            _logger = logger;

        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            if (CheckIfNameIsExist(product.ProductName).Success)
            {
                _productDal.Add(product);

                return new SuccessResult(Messages.ProductAdded);
            }
            return new ErrorResult(Messages.NameIsAlreadyExist);
            
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            

            //business codes
            //validation

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        private IResult CheckIfCategoryIsCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfNameIsExist(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Count;
            if (result > 0 )
            {
                return new ErrorResult(Messages.NameIsAlreadyExist);
            }
            return new SuccessResult();
            
            
        }
    }
}

