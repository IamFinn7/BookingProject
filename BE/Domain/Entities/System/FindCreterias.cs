namespace Domain.Entities.System
{
    public class FindCreterias : PagingCreterias
    {
        public List<string> SearchTerm { get; set; } = new List<string>();
        public static FindCreterias Empty => new();
    }
}
