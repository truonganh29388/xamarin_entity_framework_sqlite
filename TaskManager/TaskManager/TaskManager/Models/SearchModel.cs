namespace TaskManager.Models
{
   public class SearchModel
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 10;
        public string SearchContent { get; set; }
    }
}
