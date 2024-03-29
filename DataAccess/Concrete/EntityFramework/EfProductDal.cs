﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.DataFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock
                             };
                return result.ToList();
                            
                             
            }
        }
        //public List<ProductDetailDto> GetUnitPricebyCategory()
        //{
        //    using(NorthwindContext context = new NorthwindContext())
        //    {
        //        var result = from p in context.Products
        //                     join u in context.Categories
        //                     on p.UnitPrice equals u.CategoryName
        //                     select new ProductDetailDto
        //                     {
        //                         ProductId = p.ProductId,
        //                         ProductName = p.ProductName,

        //                     }
        //    }
        //    return Ok();
        //}
    }
}

