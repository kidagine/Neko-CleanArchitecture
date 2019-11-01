namespace NekoPetShop.Core.Entity
{
    public enum OrderByType { Ascending, Descending };
    public enum SortType { Id, Name, Price, Birthday, ProductDate };

    public class Filter
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
		public AnimalType AnimalType { get; set; }
		public SortType SortType { get; set; }
		public OrderByType OrderByType { get; set; }
    }
}
