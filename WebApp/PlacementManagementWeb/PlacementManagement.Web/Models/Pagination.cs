
namespace PlacementManagement.Web.Models
{
    public class Pagination : IPagination
    {
        public Pagination()
        {
            Page = 1;
            Limit = 20;
        }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}