using System.Collections.Generic;

namespace NekoPetShop.Core.Entity.Filtering
{
	public class FilteredList <T>
	{
		public int TotalPages { get; set; }
		public IEnumerable<T> List { get; set; }
	}
}
