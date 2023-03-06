using System;
namespace Core.CrossCuttingConcerns.Caching
{
	public interface ICacheManager
	{
		void Add(string key, object value, int duration);
	}
}

