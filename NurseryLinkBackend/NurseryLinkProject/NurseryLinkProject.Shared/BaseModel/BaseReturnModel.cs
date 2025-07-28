namespace NurseryLinkProject.Shared.BaseModel
{
    public class BaseReturnModel<T>
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public IEnumerable<T>? DataList { get; set; }
        public string? Token { get; set; }
        public int? pageNumber { get; set; }
        public int? pageSize { get; set; }
        public int? totalPages { get; set; }
        public int? totalCount { get; set; }
    }
}
