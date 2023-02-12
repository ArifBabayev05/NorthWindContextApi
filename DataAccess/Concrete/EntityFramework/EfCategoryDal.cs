using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess.DataFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
	{

    }
}

