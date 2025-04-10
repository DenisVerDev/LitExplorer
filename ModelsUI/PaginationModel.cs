namespace LitExplorer.ModelsUI
{
    public class PaginationModel
    {
        public int PageSize { get; init; }
        public int TotalPages { get; set; }
        public int CurrentPage { get;set; }
    }
}
