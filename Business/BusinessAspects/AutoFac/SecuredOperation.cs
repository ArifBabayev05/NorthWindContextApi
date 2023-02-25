using System;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Business.Constants;
using Core.Extensions;

namespace Business.BusinessAspects.AutoFac
{
	public class SecuredOperation : MethodInterception
	{
		private string[] _roles;
		//Install Nuget Package = HTTP.Accessor
		private IHttpContextAccessor _httpContextAccessor;

		public SecuredOperation(string roles)
		{
			_roles = roles.Split(",");
			_httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
		}

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}

