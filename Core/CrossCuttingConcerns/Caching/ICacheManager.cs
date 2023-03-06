using System;
namespace Core.CrossCuttingConcerns.Caching
{
	public interface ICacheManager
	{
		T Get<T>(string key);

		object Get(string key);

		void Add(string key, object value, int duration);

		bool IsAdd(string key);

		void Remove(string key);

		//Remove with specific pattern, such as "Methods which starting with Get"
		// or Remove if "Category" has exist on the name on method
		void RemoveByPattern(string pattern);



	}
}

