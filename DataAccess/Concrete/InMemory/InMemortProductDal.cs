using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
	public class InMemortProductDal : IProductDal
	{
        List<Product> _products;

        public InMemortProductDal()
        {
            _products = new List<Product>
            {
                new Product{ ProductId = 1,CategoryId = 1,ProductName = "Cola",UnitPrice = 15,UnitsInStock = 2},
                new Product{ ProductId = 2,CategoryId = 2,ProductName = "Cola",UnitPrice = 5,UnitsInStock = 8},
                new Product{ ProductId = 3,CategoryId = 5,ProductName = "IceTea",UnitPrice = 45,UnitsInStock =6},
                new Product{ ProductId = 5,CategoryId = 8,ProductName = "Sprite",UnitPrice = 13,UnitsInStock = 5},
                new Product{ ProductId = 4,CategoryId = 5,ProductName = "Fanta",UnitPrice = 25,UnitsInStock = 24},
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {

            #region Without LINQ
            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if(product.ProductId == p.ProductId)
            //    {
            //          productToDelete = p;
            //    }
            //}
            //_products.Remove(productToDelete);
            #endregion

            //With LINQ
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _products;
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
            productToDelete.ProductName = product.ProductName;
            productToDelete.CategoryId= product.CategoryId;
            productToDelete.UnitPrice = product.UnitPrice;
            productToDelete.UnitsInStock= product.UnitsInStock;


        }
    }
}

