namespace StudyBudAPI.Models
{
	public class StudyBudQuery
	{
        public string? SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
