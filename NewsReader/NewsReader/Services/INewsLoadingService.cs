using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsReader
{
	public interface INewsLoadingService
	{
		Task<List<string>> LoadNews();
	}
}

