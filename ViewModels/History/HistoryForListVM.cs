namespace LataPrzestepneWstrzykiwanie.ViewModels.History
{
	public class HistoryForListVM
	{
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string IsLeap { get; set; }
        public string? UserId { get; set; }
        public string? UserLogin { get; set; }
        public int Year { get; set; }
    }

    public class ListHistoryForListVM
    {
        public List<HistoryForListVM> Records { get; set; }
        public int Count { get; set; }
    }
}
