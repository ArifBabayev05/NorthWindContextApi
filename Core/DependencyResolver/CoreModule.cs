using System;
using Autofac.Core;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolver
{
	public class CoreModule : ICoreModule
	{
        public void Load(IServiceCollection servicesCollection)
        {
            servicesCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}

