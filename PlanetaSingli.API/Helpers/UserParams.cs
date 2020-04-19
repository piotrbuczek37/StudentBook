namespace PlanetaSingli.API.Helpers
{
    public class UserParams
    {
        public const int MaxPageSize = 42;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 24;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
        
    }
}