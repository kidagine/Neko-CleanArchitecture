namespace NekoPetShop.Core.Entity
{
    public enum OrderByType { Ascending, Descending };
    public enum SortType { Id, Name, Birthday, SoldDate, Owner, Price };


    public class Filter
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public SortType SortType { get; set; }
        public OrderByType OrderByType { get; set; }
    }
}
