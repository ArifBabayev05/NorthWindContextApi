using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace UI
{
	public class Program
	{
		static void Main(string[] args)
		{
			ProductTest();
		}
		private static void ProductTest()
		{
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var item in productManager.GetProductDetails())
            {
                Console.WriteLine(item.ProductName + " / " + item.CategoryName);
            }
        }
	}
}

