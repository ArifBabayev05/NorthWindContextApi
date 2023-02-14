using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //IoC --> Burda IProductService işlətdik ama bu ProductManager'ə bağlıdı. Bunu Program
        //anlaya bilmədiyi üçün xəta verir. Həlli: Startup'da:
        //AddSingleton<IProductService,ProductManager> yazmaqdır.
        // Tərcüməsi: Sənə İProductService Müraciət edərsə, arxa planda onu PM() olaraq anla.

        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public List<Product> Get()
        {
            //Dependency Chain
            var result = _productService.GetAll();
            return result.Data;

            
            
        }
    }
}

