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

			var result = productManager.GetAll();

			if (result.Success)
			{
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.ProductName);
                }
            }
			else
			{
				Console.WriteLine(result.Message);
			}
            
			 
        }
	}
}

